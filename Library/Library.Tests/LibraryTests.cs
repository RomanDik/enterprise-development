using Library.Domian.Entities;
using Xunit;

namespace Library.Tests;

public class LibraryTests(LibraryFixture fixture) : IClassFixture<LibraryFixture>
{
    /// <summary>
    /// 1. Вывести информацию о выданных книгах, упорядоченных по названию
    /// </summary>
    [Fact]
    public void ShouldGetRentedBooksOrderedByTitle()
    {
        // Arrange & Act
        var result = fixture.Rentals
            .Where(r => !r.IsReturned) // только выданные (не возвращенные)
            .Select(r => r.Book)
            .OrderBy(b => b.Title)
            .ToList();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal("1984", result.First().Title); // Проверяем сортировку
    }

    /// <summary>
    /// 2. Вывести информацию о топ 5 читателей, прочитавших больше всего книг за заданный период
    /// </summary>
    [Fact]
    public void ShouldGetTop5ReadersByBooksRead()
    {
        // Arrange
        var startDate = DateTime.Now.AddDays(-35);
        var endDate = DateTime.Now;

        // Act
        var result = fixture.Rentals
            .Where(r => r.IssueDate >= startDate && r.IssueDate <= endDate && r.IsReturned)
            .GroupBy(r => r.Reader)
            .Select(g => new
            {
                Reader = g.Key,
                BooksCount = g.Count()
            })
            .OrderByDescending(x => x.BooksCount)
            .Take(5)
            .ToList();

        // Assert
        Assert.True(result.Count <= 5);
        if (result.Count > 1)
        {
            Assert.True(result[0].BooksCount >= result[1].BooksCount);
        }
    }

    /// <summary>
    /// 3. Вывести информацию о читателях, бравших книги на наибольший период времени, упорядочить по ФИО
    /// </summary>
    [Fact]
    public void ShouldGetReadersWithLongestRentalPeriodOrderedByName()
    {
        // Act
        var result = fixture.Rentals
            .GroupBy(r => r.Reader)
            .Select(g => new
            {
                Reader = g.Key,
                MaxRentalDays = g.Max(r => r.RentalDays)
            })
            .OrderByDescending(x => x.MaxRentalDays)
            .ThenBy(x => x.Reader.FullName)
            .ToList();

        // Assert
        Assert.NotEmpty(result);
        Assert.True(result.First().MaxRentalDays >= result.Last().MaxRentalDays);
    }

    /// <summary>
    /// 4. Вывести топ 5 наиболее популярных издательств за последний год
    /// </summary>
    [Fact]
    public void ShouldGetTop5PopularPublishersLastYear()
    {
        // Arrange
        var lastYear = DateTime.Now.AddYears(-1);

        // Act
        var result = fixture.Rentals
            .Where(r => r.IssueDate >= lastYear)
            .GroupBy(r => r.Book.Publisher)
            .Select(g => new
            {
                Publisher = g.Key,
                RentalCount = g.Count()
            })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .ToList();

        // Assert
        Assert.True(result.Count <= 5);
    }

    /// <summary>
    /// 5. Вывести топ 5 наименее популярных книг за последний год
    /// </summary>
    [Fact]
    public void ShouldGetTop5LeastPopularBooksLastYear()
    {
        // Arrange
        var lastYear = DateTime.Now.AddYears(-1);

        // Act
        var result = fixture.Rentals
            .Where(r => r.IssueDate >= lastYear)
            .GroupBy(r => r.Book)
            .Select(g => new
            {
                Book = g.Key,
                RentalCount = g.Count()
            })
            .OrderBy(x => x.RentalCount)
            .Take(5)
            .ToList();

        // Assert
        Assert.True(result.Count <= 5);
    }
}