using Library.Domian.Entities;
using Library.Domian.Enums;

namespace Library.Domian;

public static class DataSeeder
{
    public static List<Publisher> Publishers =>
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

    public static List<Reader> Readers =>
    [
        new() {
            Id = Guid.NewGuid(),
            FullName = "Иванов Иван Иванович",
            Address = "ул. Ленина, 1",
            Phone = "+7 999 111 11 11",
            RegistrationDate = DateTime.Now.AddMonths(-12)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Петров Пётр Петрович",
            Address = "ул. Пушкина, 25",
            Phone = "+7 999 222 22 22",
            RegistrationDate = DateTime.Now.AddMonths(-8)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Сидорова Анна Владимировна",
            Address = "пр. Мира, 15",
            Phone = "+7 999 333 33 33",
            RegistrationDate = DateTime.Now.AddMonths(-6)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Кузнецов Дмитрий Сергеевич",
            Address = "ул. Гагарина, 8",
            Phone = "+7 999 444 44 44",
            RegistrationDate = DateTime.Now.AddMonths(-10)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Попова Мария Андреевна",
            Address = "ул. Советская, 45",
            Phone = "+7 999 555 55 55",
            RegistrationDate = DateTime.Now.AddMonths(-4)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Волков Николай Игоревич",
            Address = "ул. Кирова, 12",
            Phone = "+7 999 666 66 66",
            RegistrationDate = DateTime.Now.AddMonths(-7)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Фёдорова Дарья Олеговна",
            Address = "пр. Ленинградский, 30",
            Phone = "+7 999 777 77 77",
            RegistrationDate = DateTime.Now.AddMonths(-9)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Егоров Андрей Викторович",
            Address = "ул. Садовая, 5",
            Phone = "+7 999 888 88 88",
            RegistrationDate = DateTime.Now.AddMonths(-3)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Смирнова Полина Дмитриевна",
            Address = "ул. Центральная, 18",
            Phone = "+7 999 999 99 99",
            RegistrationDate = DateTime.Now.AddMonths(-5)
        },
        new() {
            Id = Guid.NewGuid(),
            FullName = "Займов Займ Займович",
            Address = "ул. Займовая, 99",
            Phone = "+7 800 555 35 35",
            RegistrationDate = DateTime.Now.AddMonths(-2)
        }
    ];

    public static List<Book> Books =>
    [
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB001",
            CatalogCode = "FIC001",
            Author = "А.С. Пушкин",
            Title = "Евгений Онегин",
            EditionType = EditionType.Hardcover,
            Publisher = Publishers[0],
            PublisherId = Publishers[0].Id,
            PublicationYear = 2020
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB002",
            CatalogCode = "FIC002",
            Author = "Л.Н. Толстой",
            Title = "Война и мир",
            EditionType = EditionType.Hardcover,
            Publisher = Publishers[1],
            PublisherId = Publishers[1].Id,
            PublicationYear = 2019
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB003",
            CatalogCode = "SCI001",
            Author = "С. Хокинг",
            Title = "Краткая история времени",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[2],
            PublisherId = Publishers[2].Id,
            PublicationYear = 2021
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB004",
            CatalogCode = "FIC003",
            Author = "Ф.М. Достоевский",
            Title = "Преступление и наказание",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[0],
            PublisherId = Publishers[0].Id,
            PublicationYear = 2018
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB005",
            CatalogCode = "PRO001",
            Author = "Р. Мартин",
            Title = "Чистый код",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[3],
            PublisherId = Publishers[3].Id,
            PublicationYear = 2022
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB006",
            CatalogCode = "FIC004",
            Author = "М.А. Булгаков",
            Title = "Мастер и Маргарита",
            EditionType = EditionType.Hardcover,
            Publisher = Publishers[1],
            PublisherId = Publishers[1].Id,
            PublicationYear = 2020
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB007",
            CatalogCode = "SCI002",
            Author = "А. Эйнштейн",
            Title = "Теория относительности",
            EditionType = EditionType.Electronic,
            Publisher = Publishers[4],
            PublisherId = Publishers[4].Id,
            PublicationYear = 2019
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB008",
            CatalogCode = "FIC005",
            Author = "Дж. Оруэлл",
            Title = "1984",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[5],
            PublisherId = Publishers[5].Id,
            PublicationYear = 2021
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB009",
            CatalogCode = "PRO002",
            Author = "Э. Гамма",
            Title = "Паттерны проектирования",
            EditionType = EditionType.Hardcover,
            Publisher = Publishers[2],
            PublisherId = Publishers[2].Id,
            PublicationYear = 2023
        },
        new() {
            Id = Guid.NewGuid(),
            InventoryNumber = "LIB010",
            CatalogCode = "FIC006",
            Author = "Дж. Роулинг",
            Title = "Гарри Поттер и философский камень",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[6],
            PublisherId = Publishers[6].Id,
            PublicationYear = 2020
        }
    ];

    public static List<Rental> Rentals =>
    [
        // Первые 10 выдач - разные книги и читатели
        new() {
            Id = Guid.NewGuid(),
            Book = Books[0],
            BookId = Books[0].Id,
            Reader = Readers[0],
            ReaderId = Readers[0].Id,
            IssueDate = DateTime.Now.AddDays(-30),
            RentalDays = 14,
            ActualReturnDate = DateTime.Now.AddDays(-16)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[1],
            BookId = Books[1].Id,
            Reader = Readers[1],
            ReaderId = Readers[1].Id,
            IssueDate = DateTime.Now.AddDays(-25),
            RentalDays = 21,
            ActualReturnDate = DateTime.Now.AddDays(-4)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[2],
            BookId = Books[2].Id,
            Reader = Readers[2],
            ReaderId = Readers[2].Id,
            IssueDate = DateTime.Now.AddDays(-20),
            RentalDays = 7,
            ActualReturnDate = DateTime.Now.AddDays(-13)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[3],
            BookId = Books[3].Id,
            Reader = Readers[3],
            ReaderId = Readers[3].Id,
            IssueDate = DateTime.Now.AddDays(-15),
            RentalDays = 30,
            ActualReturnDate = null
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[4],
            BookId = Books[4].Id,
            Reader = Readers[4],
            ReaderId = Readers[4].Id,
            IssueDate = DateTime.Now.AddDays(-10),
            RentalDays = 10,
            ActualReturnDate = DateTime.Now.AddDays(0)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[5],
            BookId = Books[5].Id,
            Reader = Readers[5],
            ReaderId = Readers[5].Id,
            IssueDate = DateTime.Now.AddDays(-8),
            RentalDays = 14,
            ActualReturnDate = DateTime.Now.AddDays(6)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[6],
            BookId = Books[6].Id,
            Reader = Readers[6],
            ReaderId = Readers[6].Id,
            IssueDate = DateTime.Now.AddDays(-5),
            RentalDays = 5,
            ActualReturnDate = DateTime.Now.AddDays(0)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[7],
            BookId = Books[7].Id,
            Reader = Readers[7],
            ReaderId = Readers[7].Id,
            IssueDate = DateTime.Now.AddDays(-3),
            RentalDays = 7,
            ActualReturnDate = null
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[8],
            BookId = Books[8].Id,
            Reader = Readers[8],
            ReaderId = Readers[8].Id,
            IssueDate = DateTime.Now.AddDays(-2),
            RentalDays = 21,
            ActualReturnDate = DateTime.Now.AddDays(19)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[9],
            BookId = Books[9].Id,
            Reader = Readers[9],
            ReaderId = Readers[9].Id,
            IssueDate = DateTime.Now.AddDays(-1),
            RentalDays = 10,
            ActualReturnDate = DateTime.Now.AddDays(9)
        },

        new() {
            Id = Guid.NewGuid(),
            Book = Books[0],
            BookId = Books[0].Id,
            Reader = Readers[0],
            ReaderId = Readers[0].Id,
            IssueDate = DateTime.Now.AddDays(-40),
            RentalDays = 10,
            ActualReturnDate = DateTime.Now.AddDays(-30)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[1],
            BookId = Books[1].Id,
            Reader = Readers[0],
            ReaderId = Readers[0].Id,
            IssueDate = DateTime.Now.AddDays(-50),
            RentalDays = 15,
            ActualReturnDate = DateTime.Now.AddDays(-35)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[2],
            BookId = Books[2].Id,
            Reader = Readers[1],
            ReaderId = Readers[1].Id,
            IssueDate = DateTime.Now.AddDays(-45),
            RentalDays = 20,
            ActualReturnDate = DateTime.Now.AddDays(-25)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[3],
            BookId = Books[3].Id,
            Reader = Readers[1],
            ReaderId = Readers[1].Id,
            IssueDate = DateTime.Now.AddDays(-35),
            RentalDays = 25,
            ActualReturnDate = DateTime.Now.AddDays(-10)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[4],
            BookId = Books[4].Id,
            Reader = Readers[2],
            ReaderId = Readers[2].Id,
            IssueDate = DateTime.Now.AddDays(-60),
            RentalDays = 30,
            ActualReturnDate = DateTime.Now.AddDays(-30)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[5],
            BookId = Books[5].Id,
            Reader = Readers[2],
            ReaderId = Readers[2].Id,
            IssueDate = DateTime.Now.AddDays(-55),
            RentalDays = 12,
            ActualReturnDate = DateTime.Now.AddDays(-43)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[6],
            BookId = Books[6].Id,
            Reader = Readers[3],
            ReaderId = Readers[3].Id,
            IssueDate = DateTime.Now.AddDays(-70),
            RentalDays = 8,
            ActualReturnDate = DateTime.Now.AddDays(-62)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[7],
            BookId = Books[7].Id,
            Reader = Readers[4],
            ReaderId = Readers[4].Id,
            IssueDate = DateTime.Now.AddDays(-65),
            RentalDays = 18,
            ActualReturnDate = DateTime.Now.AddDays(-47)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[8],
            BookId = Books[8].Id,
            Reader = Readers[5],
            ReaderId = Readers[5].Id,
            IssueDate = DateTime.Now.AddDays(-75),
            RentalDays = 22,
            ActualReturnDate = DateTime.Now.AddDays(-53)
        },
        new() {
            Id = Guid.NewGuid(),
            Book = Books[9],
            BookId = Books[9].Id,
            Reader = Readers[6],
            ReaderId = Readers[6].Id,
            IssueDate = DateTime.Now.AddDays(-80),
            RentalDays = 5,
            ActualReturnDate = DateTime.Now.AddDays(-75)
        }
    ];
}