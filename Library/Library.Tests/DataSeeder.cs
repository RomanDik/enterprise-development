using Library.Domian.Entities;
using Library.Domian.Enums;

namespace Library.Tests;

public static class DataSeeder
{
    public static List<Publisher> GetPublishers() =>
    [
        new() { Id = Guid.NewGuid(), Name = "Эксмо" },
        new() { Id = Guid.NewGuid(), Name = "АСТ" },
        new() { Id = Guid.NewGuid(), Name = "Питер" },
        new() { Id = Guid.NewGuid(), Name = "Манн, Иванов и Фербер" },
        new() { Id = Guid.NewGuid(), Name = "Дрофа" },
        new() { Id = Guid.NewGuid(), Name = "Росмэн" },
        new() { Id = Guid.NewGuid(), Name = "Юрайт" },
        new() { Id = Guid.NewGuid(), Name = "Инфра-М" },
        new() { Id = Guid.NewGuid(), Name = "Флинта" },
        new() { Id = Guid.NewGuid(), Name = "Наука" }
    ];

    public static List<Reader> GetReaders() =>
    [
        new() { Id = Guid.NewGuid(), FullName = "Иванов Иван Иванович", Address = "ул. Ленина, 1", Phone = "+7 999 111 11 11", RegistrationDate = DateTime.Now.AddMonths(-12) },
        new() { Id = Guid.NewGuid(), FullName = "Петров Пётр Петрович", Address = "ул. Пушкина, 25", Phone = "+7 999 222 22 22", RegistrationDate = DateTime.Now.AddMonths(-8) },
        new() { Id = Guid.NewGuid(), FullName = "Сидорова Анна Владимировна", Address = "пр. Мира, 15", Phone = "+7 999 333 33 33", RegistrationDate = DateTime.Now.AddMonths(-6) },
        new() { Id = Guid.NewGuid(), FullName = "Кузнецов Дмитрий Сергеевич", Address = "ул. Гагарина, 8", Phone = "+7 999 444 44 44", RegistrationDate = DateTime.Now.AddMonths(-10) },
        new() { Id = Guid.NewGuid(), FullName = "Попова Мария Андреевна", Address = "ул. Советская, 45", Phone = "+7 999 555 55 55", RegistrationDate = DateTime.Now.AddMonths(-4) },
        new() { Id = Guid.NewGuid(), FullName = "Волков Николай Игоревич", Address = "ул. Кирова, 12", Phone = "+7 999 666 66 66", RegistrationDate = DateTime.Now.AddMonths(-7) },
        new() { Id = Guid.NewGuid(), FullName = "Фёдорова Дарья Олеговна", Address = "пр. Ленинградский, 30", Phone = "+7 999 777 77 77", RegistrationDate = DateTime.Now.AddMonths(-9) },
        new() { Id = Guid.NewGuid(), FullName = "Егоров Андрей Викторович", Address = "ул. Садовая, 5", Phone = "+7 999 888 88 88", RegistrationDate = DateTime.Now.AddMonths(-3) },
        new() { Id = Guid.NewGuid(), FullName = "Смирнова Полина Дмитриевна", Address = "ул. Центральная, 18", Phone = "+7 999 999 99 99", RegistrationDate = DateTime.Now.AddMonths(-5) },
        new() { Id = Guid.NewGuid(), FullName = "Орлова Елена Сергеевна", Address = "ул. Молодёжная, 22", Phone = "+7 900 123 45 67", RegistrationDate = DateTime.Now.AddMonths(-2) }
    ];

    public static List<Book> GetBooks(List<Publisher> publishers) =>
    [
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB001", CatalogCode = "FIC001", Author = "А.С. Пушкин", Title = "Евгений Онегин", EditionType = EditionType.Hardcover, Publisher = publishers[0], PublicationYear = 2020 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB002", CatalogCode = "FIC002", Author = "Л.Н. Толстой", Title = "Война и мир", EditionType = EditionType.Hardcover, Publisher = publishers[1], PublicationYear = 2019 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB003", CatalogCode = "SCI001", Author = "С. Хокинг", Title = "Краткая история времени", EditionType = EditionType.Paperback, Publisher = publishers[2], PublicationYear = 2021 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB004", CatalogCode = "FIC003", Author = "Ф.М. Достоевский", Title = "Преступление и наказание", EditionType = EditionType.Paperback, Publisher = publishers[0], PublicationYear = 2018 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB005", CatalogCode = "PRO001", Author = "Р. Мартин", Title = "Чистый код", EditionType = EditionType.Paperback, Publisher = publishers[3], PublicationYear = 2022 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB006", CatalogCode = "FIC004", Author = "М.А. Булгаков", Title = "Мастер и Маргарита", EditionType = EditionType.Hardcover, Publisher = publishers[1], PublicationYear = 2020 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB007", CatalogCode = "SCI002", Author = "А. Эйнштейн", Title = "Теория относительности", EditionType = EditionType.Electronic, Publisher = publishers[4], PublicationYear = 2019 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB008", CatalogCode = "FIC005", Author = "Дж. Оруэлл", Title = "1984", EditionType = EditionType.Paperback, Publisher = publishers[5], PublicationYear = 2021 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB009", CatalogCode = "PRO002", Author = "Э. Гамма", Title = "Паттерны проектирования", EditionType = EditionType.Hardcover, Publisher = publishers[2], PublicationYear = 2023 },
        new() { Id = Guid.NewGuid(), InventoryNumber = "LIB010", CatalogCode = "FIC006", Author = "Дж. Роулинг", Title = "Гарри Поттер и философский камень", EditionType = EditionType.Paperback, Publisher = publishers[6], PublicationYear = 2020 }
    ];

    public static List<Rental> GetRentals(List<Book> books, List<Reader> readers) =>
    [
        new() { Id = Guid.NewGuid(), Book = books[0], Reader = readers[0], IssueDate = DateTime.Now.AddDays(-30), RentalDays = 14, ActualReturnDate = DateTime.Now.AddDays(-16) },
        new() { Id = Guid.NewGuid(), Book = books[1], Reader = readers[1], IssueDate = DateTime.Now.AddDays(-25), RentalDays = 21, ActualReturnDate = DateTime.Now.AddDays(-4) },
        new() { Id = Guid.NewGuid(), Book = books[2], Reader = readers[2], IssueDate = DateTime.Now.AddDays(-20), RentalDays = 7, ActualReturnDate = DateTime.Now.AddDays(-13) },
        new() { Id = Guid.NewGuid(), Book = books[3], Reader = readers[3], IssueDate = DateTime.Now.AddDays(-15), RentalDays = 30, ActualReturnDate = null }, // Не возвращена
        new() { Id = Guid.NewGuid(), Book = books[4], Reader = readers[4], IssueDate = DateTime.Now.AddDays(-10), RentalDays = 10, ActualReturnDate = DateTime.Now.AddDays(0) },
        new() { Id = Guid.NewGuid(), Book = books[5], Reader = readers[5], IssueDate = DateTime.Now.AddDays(-8), RentalDays = 14, ActualReturnDate = DateTime.Now.AddDays(6) },
        new() { Id = Guid.NewGuid(), Book = books[6], Reader = readers[6], IssueDate = DateTime.Now.AddDays(-5), RentalDays = 5, ActualReturnDate = DateTime.Now.AddDays(0) },
        new() { Id = Guid.NewGuid(), Book = books[7], Reader = readers[7], IssueDate = DateTime.Now.AddDays(-3), RentalDays = 7, ActualReturnDate = null }, // Не возвращена
        new() { Id = Guid.NewGuid(), Book = books[8], Reader = readers[8], IssueDate = DateTime.Now.AddDays(-2), RentalDays = 21, ActualReturnDate = DateTime.Now.AddDays(19) },
        new() { Id = Guid.NewGuid(), Book = books[9], Reader = readers[9], IssueDate = DateTime.Now.AddDays(-1), RentalDays = 10, ActualReturnDate = DateTime.Now.AddDays(9) },
        
        new() { Id = Guid.NewGuid(), Book = books[0], Reader = readers[0], IssueDate = DateTime.Now.AddDays(-40), RentalDays = 10, ActualReturnDate = DateTime.Now.AddDays(-30) },
        new() { Id = Guid.NewGuid(), Book = books[1], Reader = readers[0], IssueDate = DateTime.Now.AddDays(-50), RentalDays = 15, ActualReturnDate = DateTime.Now.AddDays(-35) },
        new() { Id = Guid.NewGuid(), Book = books[2], Reader = readers[1], IssueDate = DateTime.Now.AddDays(-45), RentalDays = 20, ActualReturnDate = DateTime.Now.AddDays(-25) },
        new() { Id = Guid.NewGuid(), Book = books[3], Reader = readers[1], IssueDate = DateTime.Now.AddDays(-35), RentalDays = 25, ActualReturnDate = DateTime.Now.AddDays(-10) },
        new() { Id = Guid.NewGuid(), Book = books[4], Reader = readers[2], IssueDate = DateTime.Now.AddDays(-60), RentalDays = 30, ActualReturnDate = DateTime.Now.AddDays(-30) },
        new() { Id = Guid.NewGuid(), Book = books[5], Reader = readers[2], IssueDate = DateTime.Now.AddDays(-55), RentalDays = 12, ActualReturnDate = DateTime.Now.AddDays(-43) },
        new() { Id = Guid.NewGuid(), Book = books[6], Reader = readers[3], IssueDate = DateTime.Now.AddDays(-70), RentalDays = 8, ActualReturnDate = DateTime.Now.AddDays(-62) },
        new() { Id = Guid.NewGuid(), Book = books[7], Reader = readers[4], IssueDate = DateTime.Now.AddDays(-65), RentalDays = 18, ActualReturnDate = DateTime.Now.AddDays(-47) },
        new() { Id = Guid.NewGuid(), Book = books[8], Reader = readers[5], IssueDate = DateTime.Now.AddDays(-75), RentalDays = 22, ActualReturnDate = DateTime.Now.AddDays(-53) },
        new() { Id = Guid.NewGuid(), Book = books[9], Reader = readers[6], IssueDate = DateTime.Now.AddDays(-80), RentalDays = 5, ActualReturnDate = DateTime.Now.AddDays(-75) }
    ];
}