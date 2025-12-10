using Library.Application.Contracts.Analytics;
using Library.Application.Contracts.Books;
using Library.Application.Contracts.Readers;

namespace Library.Application.Contracts;

/// <summary>
/// Интерфейс сервиса для получения аналитической информации по данным библиотеки
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Получает информацию о выданных и не возвращённых книгах, упорядоченных по названию
    /// </summary>
    /// <returns>Список BookDto выданных книг</returns>
    public Task<IList<BookDto>> GetRentedBooksOrderedByTitle();

    /// <summary>
    /// Получает информацию о читателях с активными выдачами, упорядоченных по ФИО
    /// </summary>
    /// <returns>Список ReaderDto читателей</returns>
    public Task<IList<ReaderDto>> GetReadersWithActiveRentalsOrderedByName();

    /// <summary>
    /// Получает информацию о читателях, бравших книги на максимальный срок, упорядоченных по ФИО
    /// </summary>
    /// <returns>Список ReaderDto читателей</returns>
    public Task<IList<ReaderDto>> GetReadersWithLongestRentalPeriodOrderedByName();

    /// <summary>
    /// Получает топ 5 наиболее популярных издательств за последний год
    /// </summary>
    /// <param name="fromDate">Дата начала периода</param>
    /// <returns>Список DTO издательств с количеством выдач</returns>
    public Task<IList<TopPublisherAnalyticsDto>> GetTop5PopularPublishers(DateTime fromDate);

    /// <summary>
    /// Получает топ 5 наименее популярных книг за последний год
    /// </summary>
    /// <param name="fromDate">Дата начала периода</param>
    /// <returns>Список DTO книг с количеством выдач</returns>
    public Task<IList<BookPopularityAnalyticsDto>> GetTop5LeastPopularBooks(DateTime fromDate);
}
