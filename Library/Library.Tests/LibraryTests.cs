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
        // Arrange
        var expectedCount = fixture.Rentals.Count(r => !r.IsReturned);

        // Act
        var result = fixture.Rentals
            .Where(r => !r.IsReturned)
            .Select(r => r.Book)
            .OrderBy(b => b.Title)
            .ToList();

        // Assert
        Assert.Equal(expectedCount, result.Count); 
    }

    /// <summary>
    /// 2. Вывести информацию о топ 5 читателей, прочитавших больше всего книг за заданный период
    /// </summary>
    [Fact]
    public void ShouldGetTop5ReadersByBooksRead()
    {
        // Arrange
        var expectedCount = 5; 

        // Act
        var result = fixture.Rentals
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
        Assert.Equal(expectedCount, result.Count); 
    }

    /// <summary>
    /// 3. Вывести информацию о читателях, бравших книги на наибольший период времени, упорядочить по ФИО
    /// </summary>
    [Fact]
    public void ShouldGetReadersWithLongestRentalPeriodOrderedByName()
    {
        // Arrange
        var maxRentalDays = fixture.Rentals.Max(r => r.RentalDays);
        var expectedCount = fixture.Rentals
            .Where(r => r.RentalDays == maxRentalDays)
            .Select(r => r.Reader)
            .Distinct()
            .Count();

        // Act 
        var result = fixture.Rentals
            .Where(r => r.RentalDays == maxRentalDays) 
            .GroupBy(r => r.Reader)
            .Select(g => new
            {
                Reader = g.Key,
                MaxRentalDays = g.Max(r => r.RentalDays)
            })
            .OrderBy(x => x.Reader.FullName) 
            .ToList();

        // Assert
        Assert.Equal(expectedCount, result.Count); 
        Assert.All(result, x => Assert.Equal(maxRentalDays, x.MaxRentalDays));
    }

    /// <summary>
    /// 4. Вывести топ 5 наиболее популярных издательств за последний год
    /// </summary>
    [Fact]
    public void ShouldGetTop5PopularPublishersLastYear()
    {
        // Arrange
        var lastYear = new DateTime(2023, 1, 1); 
        var expectedCount = 5; 

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
        Assert.Equal(expectedCount, result.Count); 
    }

    /// <summary>
    /// 5. Вывести топ 5 наименее популярных книг за последний год
    /// </summary>
    [Fact]
    public void ShouldGetTop5LeastPopularBooksLastYear()
    {
        // Arrange
        var lastYear = new DateTime(2023, 1, 1); 
        var expectedCount = 5; 

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
        Assert.Equal(expectedCount, result.Count); 
    }
}