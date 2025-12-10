using AutoMapper;
using Library.Application.Contracts;
using Library.Application.Contracts.Analytics;
using Library.Application.Contracts.Books;
using Library.Application.Contracts.Publishers;
using Library.Application.Contracts.Readers;
using Library.Entities;

namespace Library.Application.Services;

/// <summary>
/// Сервис для получения аналитической информации по данным библиотеки
/// </summary>
public class AnalyticsService(
    IRepository<Rental, Guid> rentalRepository,
    IRepository<Book, Guid> bookRepository,
    IRepository<Publisher, Guid> publisherRepository,
    IMapper mapper) : IAnalyticsService
{
    /// <summary>
    /// Получает информацию о выданных и не возвращённых книгах, упорядоченных по названию
    /// </summary>
    /// <returns>Список BookDto выданных книг</returns>
    public async Task<IList<BookDto>> GetRentedBooksOrderedByTitle()
    {
        var rentals = await rentalRepository.ReadAll();

        var books = rentals
            .Where(r => !r.IsReturned)
            .Select(r => r.Book)
            .OrderBy(b => b.Title)
            .ToList();

        return [.. books.Select(mapper.Map<BookDto>)];
    }

    /// <summary>
    /// Получает информацию о читателях с активными выдачами, упорядоченных по ФИО
    /// </summary>
    /// <returns>Список ReaderDto читателей</returns>
    public async Task<IList<ReaderDto>> GetReadersWithActiveRentalsOrderedByName()
    {
        var rentals = await rentalRepository.ReadAll();

        var readers = rentals
            .Where(r => !r.IsReturned)
            .Select(r => r.Reader)
            .Distinct()
            .OrderBy(r => r.FullName)
            .ToList();

        return [.. readers.Select(mapper.Map<ReaderDto>)];
    }

    /// <summary>
    /// Получает информацию о читателях, бравших книги на максимальный срок, упорядоченных по ФИО
    /// </summary>
    /// <returns>Список ReaderDto читателей</returns>
    public async Task<IList<ReaderDto>> GetReadersWithLongestRentalPeriodOrderedByName()
    {
        var rentals = await rentalRepository.ReadAll();
        if (rentals.Count == 0) return [];

        var maxDays = rentals.Max(r => r.RentalDays);

        var readers = rentals
            .Where(r => r.RentalDays == maxDays)
            .Select(r => r.Reader)
            .Distinct()
            .OrderBy(r => r.FullName)
            .ToList();

        return [.. readers.Select(mapper.Map<ReaderDto>)];
    }

    /// <summary>
    /// Получает топ 5 наиболее популярных издательств за последний год
    /// </summary>
    /// <param name="fromDate">Дата начала периода</param>
    /// <returns>Список DTO издательств с количеством выдач</returns>
    public async Task<IList<TopPublisherAnalyticsDto>> GetTop5PopularPublishers(DateTime fromDate)
    {
        var rentals = await rentalRepository.ReadAll();

        var top = rentals
            .Where(r => r.IssueDate >= fromDate)
            .GroupBy(r => r.Book.PublisherId)
            .Select(g => new
            {
                PublisherId = g.Key,
                RentalCount = g.Count()
            })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .ToList();

        var result = new List<TopPublisherAnalyticsDto>(top.Count);

        foreach (var item in top)
        {
            var publisher = await publisherRepository.Read(item.PublisherId);
            if (publisher is null) continue;

            result.Add(new TopPublisherAnalyticsDto(
                mapper.Map<PublisherDto>(publisher),
                item.RentalCount
            ));
        }

        return result;
    }

    /// <summary>
    /// Получает топ 5 наименее популярных книг за последний год
    /// </summary>
    /// <param name="fromDate">Дата начала периода</param>
    /// <returns>Список DTO книг с количеством выдач</returns>
    public async Task<IList<BookPopularityAnalyticsDto>> GetTop5LeastPopularBooks(DateTime fromDate)
    {
        var rentals = await rentalRepository.ReadAll();

        var top = rentals
            .Where(r => r.IssueDate >= fromDate)
            .GroupBy(r => r.BookId)
            .Select(g => new
            {
                BookId = g.Key,
                RentalCount = g.Count()
            })
            .OrderBy(x => x.RentalCount)
            .Take(5)
            .ToList();

        var result = new List<BookPopularityAnalyticsDto>(top.Count);

        foreach (var item in top)
        {
            var book = await bookRepository.Read(item.BookId);
            if (book is null) continue;

            result.Add(new BookPopularityAnalyticsDto(
                mapper.Map<BookDto>(book),
                item.RentalCount
            ));
        }

        return result;
    }
}