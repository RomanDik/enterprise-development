using Library.Domian.Entities;
using Library.Domian.Enums;


namespace Library.Tests;

public class LibraryFixture
{
    public List<Publisher> Publishers { get; private set; }
    public List<Reader> Readers { get; private set; }
    public List<Book> Books { get; private set; }
    public List<Rental> Rentals { get; private set; }

    public LibraryFixture()
    {
        Publishers = DataSeeder.GetPublishers();
        Readers = DataSeeder.GetReaders();
        Books = DataSeeder.GetBooks(Publishers);
        Rentals = DataSeeder.GetRentals(Books, Readers);
    }
}