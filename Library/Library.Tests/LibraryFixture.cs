using Library.Domian.Entities;
using Library.Domian;

namespace Library.Tests;

public class LibraryFixture
{
    public List<Publisher> Publishers { get; private set; }
    public List<Reader> Readers { get; private set; }
    public List<Book> Books { get; private set; }
    public List<Rental> Rentals { get; private set; }

    public LibraryFixture()
    {
        Publishers = DataSeeder.Publishers;
        Readers = DataSeeder.Readers;
        Books = DataSeeder.Books;
        Rentals = DataSeeder.Rentals;
    }
}