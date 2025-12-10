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
        var expectedCount = 2; 
        var expectedFirstTitle = "1984";
        var expectedSecondTitle = "Преступление и наказание";

        // Act
        var result = fixture.Rentals
            .Where(r => !r.IsReturned)
            .Select(r => r.Book)
            .OrderBy(b => b.Title)
            .ToList();

        // Assert
        Assert.Equal(expectedCount, result.Count);
        Assert.Equal(expectedFirstTitle, result[0].Title);
        Assert.Equal(expectedSecondTitle, result[1].Title);
    }

    /// <summary>
    /// 2. Вывести информацию о читателях с активными (не возвращенными) арендами книг
    /// </summary>
    [Fact]
    public void ShouldGetReadersWithActiveRentals()
    {
        // Arrange
        var expectedCount = 2; 
        var expectedReader1 = "Егоров Андрей Викторович";
        var expectedReader2 = "Кузнецов Дмитрий Сергеевич";

        // Act - читатели с НЕ возвращенными книгами
        var result = fixture.Rentals
            .Where(r => !r.IsReturned)
            .Select(r => r.Reader)
            .Distinct()
            .OrderBy(r => r.FullName)
            .ToList();

        // Assert
        Assert.Equal(expectedCount, result.Count);
        Assert.Equal(expectedReader1, result[0].FullName);
        Assert.Equal(expectedReader2, result[1].FullName);
    }

    /// <summary>
    /// 3. Вывести информацию о читателях, бравших книги на наибольший период времени
    /// </summary>
    [Fact]
    public void ShouldGetReadersWithLongestRentalPeriodOrderedByName()
    {
        // Arrange
        var expectedCount = 2; 
        var expectedMaxRentalDays = 30;

        var actualMaxRentalDays = fixture.Rentals.Max(r => r.RentalDays);

        // Act 
        var result = fixture.Rentals
            .Where(r => r.RentalDays == actualMaxRentalDays)
            .Select(r => new
            {
                r.Reader,
                r.RentalDays
            })
            .Distinct() 
            .OrderBy(x => x.Reader.FullName)
            .ToList();

        // Assert
        Assert.Equal(expectedCount, result.Count);
        Assert.All(result, x => Assert.Equal(expectedMaxRentalDays, x.RentalDays));
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