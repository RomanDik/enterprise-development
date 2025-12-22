using Bogus;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Library.Application.Contracts.Protos;
using Microsoft.Extensions.Options;

namespace Library.RentalGenerator.Services;

/// <summary>
/// gRPC сервис генерации контрактов аренды с bidirectional streaming
/// </summary>
public class RentalGeneratorService(ILogger<RentalGeneratorService> logger, IOptions<RentalGenerationOptions> options) : Application.Contracts.Protos.RentalGenerator.RentalGeneratorBase
{
    private readonly RentalGenerationOptions _options = options.Value;

    private static readonly string[] _bookIds =
    [
        "50000000-0000-0000-0000-000000000001",
        "50000000-0000-0000-0000-000000000002",
        "50000000-0000-0000-0000-000000000003",
        "50000000-0000-0000-0000-000000000004",
        "50000000-0000-0000-0000-000000000005",
        "50000000-0000-0000-0000-000000000006",
        "50000000-0000-0000-0000-000000000007",
        "50000000-0000-0000-0000-000000000008",
        "50000000-0000-0000-0000-000000000009",
        "50000000-0000-0000-0000-000000000010",
        "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
        "f7e6d5c4-b3a2-1098-7654-321fedcba098",
        "12345678-1234-1234-1234-123456789012"
    ];

    private static readonly string[] _readerIds =
    [
        "BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB",
        "CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC",
        "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDDDD",
        "EEEEEEEE-EEEE-EEEE-EEEE-EEEEEEEEEEEE",
        "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF",
        "01234567-89AB-CDEF-0123-456789ABCDEF",
        "12345678-9ABC-DEF0-1234-56789ABCDEF0",
        "23456789-ABCD-EF01-2345-6789ABCDEF01",
        "3456789A-BCDE-F012-3456-789ABCDEF012",
        "456789AB-CDEF-0123-4567-89ABCDEF0123",
        "98765432-abcd-ef01-2345-6789abcdef01",
        "abcdef12-3456-7890-abcd-ef1234567890",
        "11111111-2222-3333-4444-555566667777"
    ];

    /// <summary>
    /// Bidirectional streaming: принимает запросы на генерацию, отправляет сгенерированные контракты
    /// </summary>
    public override async Task StreamRentals(
        IAsyncStreamReader<RentalRequest> requestStream,
        IServerStreamWriter<RentalResponse> responseStream,
        ServerCallContext context)
    {
        var batchSize = _options.BatchSize;
        var batchDelayMs = _options.BatchDelayMs;

        logger.LogInformation("Bidirectional streaming started. BatchSize: {BatchSize}, BatchDelayMs: {BatchDelayMs}", batchSize, batchDelayMs);

        await foreach (var request in requestStream.ReadAllAsync(context.CancellationToken))
        {
            logger.LogInformation("Received request to generate {Count} rentals", request.Count);

            var totalToGenerate = request.Count;
            var generated = 0;

            while (generated < totalToGenerate && !context.CancellationToken.IsCancellationRequested)
            {
                var currentBatchSize = Math.Min(batchSize, totalToGenerate - generated);

                for (var i = 0; i < currentBatchSize; i++)
                {
                    var rental = GenerateRental();
                    await responseStream.WriteAsync(rental, context.CancellationToken);
                    generated++;

                    logger.LogDebug("Generated rental {Index}/{Total}: BookId={BookId}, ReaderId={ReaderId}",
                        generated, totalToGenerate, rental.BookId, rental.ReaderId);
                }

                if (generated < totalToGenerate)
                {
                    logger.LogDebug("Batch complete. Waiting {DelayMs}ms before next batch...", batchDelayMs);
                    await Task.Delay(batchDelayMs, context.CancellationToken);
                }
            }

            logger.LogInformation("Completed generating {Count} rentals for request", totalToGenerate);
        }

        logger.LogInformation("Bidirectional streaming completed");
    }

    /// <summary>
    /// Генерирует случайный контракт аренды с помощью Bogus
    /// </summary>
    private static RentalResponse GenerateRental()
    {
        return new Faker<RentalResponse>("ru")
            .CustomInstantiator(f =>
            {
                var issueDate = f.Date.Between(DateTime.UtcNow.AddMonths(-6), DateTime.UtcNow);
                var rentalDays = f.Random.Int(7, 30);
                var hasReturnDate = f.Random.Bool(0.7f);
                var status = hasReturnDate
                    ? f.PickRandom(RentalStatus.Returned, RentalStatus.Returned, RentalStatus.Overdue)
                    : f.PickRandom(RentalStatus.Active, RentalStatus.Overdue, RentalStatus.Lost);

                var response = new RentalResponse
                {
                    BookId = f.PickRandom(_bookIds),
                    ReaderId = f.PickRandom(_readerIds),
                    IssueDate = Timestamp.FromDateTime(DateTime.SpecifyKind(issueDate, DateTimeKind.Utc)),
                    RentalDays = rentalDays,
                    HasActualReturnDate = hasReturnDate,
                    Status = status
                };

                if (hasReturnDate)
                {
                    var returnDate = issueDate.AddDays(f.Random.Int(1, rentalDays + 10));
                    response.ActualReturnDate = Timestamp.FromDateTime(DateTime.SpecifyKind(returnDate, DateTimeKind.Utc));
                }

                return response;
            })
            .Generate();
    }
}