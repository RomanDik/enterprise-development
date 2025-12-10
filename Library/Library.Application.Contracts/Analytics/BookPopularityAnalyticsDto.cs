using Library.Application.Contracts.Books;

namespace Library.Application.Contracts.Analytics;

/// <summary>
/// DTO для получения аналитики по популярности книги с количеством выдач за период
/// </summary>
/// <param name="Book">Книга</param>
/// <param name="RentalCount">Количество выдач за период</param>
public record BookPopularityAnalyticsDto(
    BookDto Book,
    int RentalCount
);