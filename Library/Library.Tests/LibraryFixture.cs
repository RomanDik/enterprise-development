using Library.Entities;

namespace Library.Tests;

public class LibraryFixture
{
    public List<Publisher> Publishers => DataSeeder.Publishers;
    public List<Reader> Readers => DataSeeder.Readers;
    public List<Book> Books => DataSeeder.Books;
    public List<Rental> Rentals => DataSeeder.Rentals;
}