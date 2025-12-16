using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Library.Infrastructure;

/// <summary>
/// Контекст базы данных для библиотеки на MongoDB
/// </summary>
public class LibraryDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// Коллекция книг
    /// </summary>
    public DbSet<Book> Books => Set<Book>();

    /// <summary>
    /// Коллекция записей о выдаче книг
    /// </summary>
    public DbSet<Rental> Rentals => Set<Rental>();

    /// <summary>
    /// Коллекция издательств
    /// </summary>
    public DbSet<Publisher> Publishers => Set<Publisher>();

    /// <summary>
    /// Коллекция читателей
    /// </summary>
    public DbSet<Reader> Readers => Set<Reader>();

    /// <summary>
    /// Настройка моделей и связей
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var dateOnlyConverter = new ValueConverter<DateOnly, string>(
            v => v.ToString("yyyy-MM-dd"),
            v => DateOnly.Parse(v)
        );


        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToCollection("books");
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Id).HasElementName("_id");

            entity.Property(b => b.InventoryNumber)
                .HasElementName("inventoryNumber")
                .HasMaxLength(50);

            entity.Property(b => b.CatalogCode)
                .HasElementName("catalogCode")
                .HasMaxLength(50);

            entity.Property(b => b.Author)
                .HasElementName("author")
                .HasMaxLength(256);

            entity.Property(b => b.Title)
                .HasElementName("title")
                .HasMaxLength(256);

            entity.Property(b => b.EditionType)
                .HasElementName("editionType")
                .HasConversion<string>();

            entity.Property(b => b.PublisherId)
                .HasElementName("publisherId");

            entity.Property(b => b.Publisher)
                .HasElementName("publisher");

            entity.Property(b => b.PublicationYear)
                .HasElementName("publicationYear");

            entity.Property(b => b.Status)
                .HasElementName("status")
                .HasConversion<string>();

            entity.Property(b => b.CreatedDate)
                .HasElementName("createdDate");

            entity.Ignore(b => b.Publisher);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.ToCollection("publishers");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasElementName("_id");

            entity.Property(p => p.Name)
                .HasElementName("name")
                .HasMaxLength(100);

            entity.Property(p => p.ContactInfo)
                .HasElementName("contactInfo")
                .HasMaxLength(512);

            entity.Property(p => p.Website)
                .HasElementName("website")
                .HasMaxLength(256);

            entity.Ignore(p => p.Books);
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.ToCollection("readers");
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Id).HasElementName("_id");

            entity.Property(r => r.FullName)
                .HasElementName("fullName")
                .HasMaxLength(256);

            entity.Property(r => r.Address)
                .HasElementName("address")
                .HasMaxLength(512);

            entity.Property(r => r.Phone)
                .HasElementName("phone")
                .HasMaxLength(50);

            entity.Property(r => r.RegistrationDate)
                .HasElementName("registrationDate");

            entity.Property(r => r.Email)
                .HasElementName("email")
                .HasMaxLength(256);

            entity.Property(r => r.BirthDate)
                .HasElementName("birthDate")
                .HasConversion(dateOnlyConverter);

            entity.Ignore(r => r.Rentals);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.ToCollection("rentals");
            entity.HasKey(l => l.Id);

            entity.Property(l => l.Id).HasElementName("_id");

            entity.Property(l => l.BookId)
                .HasElementName("bookId");

            entity.Property(l => l.Book)
                .HasElementName("book");

            entity.Property(l => l.ReaderId)
                .HasElementName("readerId");

            entity.Property(l => l.Reader)
                .HasElementName("reader");

            entity.Property(l => l.IssueDate)
                .HasElementName("issueDate");

            entity.Property(l => l.RentalDays)
                .HasElementName("rentalDays");

            entity.Property(l => l.ActualReturnDate)
                .HasElementName("actualReturnDate");

            entity.Property(l => l.Status)
                .HasElementName("status")
                .HasConversion<string>();

            entity.Ignore(l => l.Book);
            entity.Ignore(l => l.Reader);

            entity.Ignore(l => l.ExpectedReturnDate);
            entity.Ignore(l => l.IsReturned);
        });

        Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
    }
}