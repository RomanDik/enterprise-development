using Grpc.Core;
using Grpc.Net.Client;
using Library.Application.Contracts;
using Library.Application.Contracts.Protos;
using Library.Application.Contracts.Rentals;
using Microsoft.Extensions.Options;

namespace Library.Api.Host.Services;

/// <summary>
/// Фоновый сервис для получения сгенерированных контрактов аренды через gRPC bidirectional streaming
/// </summary>
public class RentalStreamingService(
    IServiceScopeFactory scopeFactory,
    ILogger<RentalStreamingService> logger,
    IConfiguration configuration,
    IOptions<RentalStreamingOptions> options) : BackgroundService
{
    private readonly string _grpcAddress = configuration.GetConnectionString("rental-generator")
        ?? configuration["Services:RentalGenerator:Url"]
        ?? "http://localhost:5201";
    private readonly RentalStreamingOptions _options = options.Value;

    /// <inheritdoc />
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(5000, stoppingToken);

        var requestCount = _options.RequestCount;
        var requestIntervalMs = _options.RequestIntervalMs;

        logger.LogInformation("Starting RentalStreamingService. Generator address: {Address}", _grpcAddress);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await StreamRentalsAsync(requestCount, stoppingToken);
                
                logger.LogInformation("Waiting {IntervalMs}ms before next request batch...", requestIntervalMs);
                await Task.Delay(requestIntervalMs, stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("RentalStreamingService is stopping");
                break;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in RentalStreamingService. Retrying...");
                await Task.Delay(10000, stoppingToken);
            }
        }
    }

    /// <summary>
    /// Открывает bidirectional stream для получения сгенерированных контрактов аренды
    /// </summary>
    private async Task StreamRentalsAsync(int count, CancellationToken cancellationToken)
    {
        using var channel = GrpcChannel.ForAddress(_grpcAddress);
        var client = new RentalGenerator.RentalGeneratorClient(channel);

        logger.LogInformation("Opening bidirectional stream to request {Count} rentals", count);

        using var call = client.StreamRentals(cancellationToken: cancellationToken);

        var request = new RentalRequest { Count = count };
        await call.RequestStream.WriteAsync(request, cancellationToken);
        await call.RequestStream.CompleteAsync();

        logger.LogInformation("Sent request for {Count} rentals, waiting for responses...", count);

        var successCount = 0;
        var failureCount = 0;

        await foreach (var response in call.ResponseStream.ReadAllAsync(cancellationToken))
        {
            try
            {
                var dto = MapToDto(response);
                await SaveRentalAsync(dto);
                successCount++;
                
                logger.LogInformation("Successfully saved rental: BookId={BookId}, ReaderId={ReaderId}",
                    response.BookId, response.ReaderId);
            }
            catch (Exception ex)
            {
                failureCount++;
                logger.LogWarning(ex, "Failed to save rental: BookId={BookId}, ReaderId={ReaderId}. Reason: {Reason}",
                    response.BookId, response.ReaderId, ex.Message);
            }
        }

        logger.LogInformation("Stream completed. Success: {SuccessCount}, Failures: {FailureCount}",
            successCount, failureCount);
    }

    /// <summary>
    /// Преобразует gRPC ответ в DTO для создания аренды
    /// </summary>
    private static RentalCreateUpdateDto MapToDto(RentalResponse response)
    {
        return new RentalCreateUpdateDto(
            BookId: Guid.Parse(response.BookId),
            ReaderId: Guid.Parse(response.ReaderId),
            IssueDate: response.IssueDate.ToDateTime(),
            RentalDays: response.RentalDays,
            ActualReturnDate: response.HasActualReturnDate ? response.ActualReturnDate.ToDateTime() : null,
            Status: MapStatus(response.Status)
        );
    }

    /// <summary>
    /// Преобразует статус аренды из protobuf в доменный enum
    /// </summary>
    private static Domain.Enums.RentalStatus MapStatus(RentalStatus protoStatus)
    {
        return protoStatus switch
        {
            RentalStatus.Active => Domain.Enums.RentalStatus.Active,
            RentalStatus.Returned => Domain.Enums.RentalStatus.Returned,
            RentalStatus.Overdue => Domain.Enums.RentalStatus.Overdue,
            RentalStatus.Lost => Domain.Enums.RentalStatus.Lost,
            _ => Domain.Enums.RentalStatus.Active
        };
    }

    /// <summary>
    /// Сохраняет сгенерированный контракт аренды в базу данных
    /// </summary>
    private async Task SaveRentalAsync(RentalCreateUpdateDto dto)
    {
        using var scope = scopeFactory.CreateScope();
        var rentalService = scope.ServiceProvider.GetRequiredService<IApplicationService<RentalDto, RentalCreateUpdateDto, Guid>>();

        await rentalService.Create(dto);
    }
}