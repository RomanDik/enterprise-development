using Library.Application.Contracts.Publishers;

namespace Library.Application.Contracts.Analytics;

/// <summary>
/// DTO для получения аналитики по издательству с количеством выдач за период
/// </summary>
/// <param name="Publisher">Издательство</param>
/// <param name="RentalCount">Количество выдач за период</param>
public record TopPublisherAnalyticsDto(
    PublisherDto Publisher,
    int RentalCount
);