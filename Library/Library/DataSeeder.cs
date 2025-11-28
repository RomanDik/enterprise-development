using Library.Entities;
using Library.Enums;

namespace Library;

public static class DataSeeder
{
    public static List<Publisher> Publishers =>
    [
        new()
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Эксмо"
        },
        new()
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "АСТ"
        },
        new()
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Питер"
        },
        new()
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Name = "Манн, Иванов и Фербер"
        },
        new()
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Name = "Дрофа"
        },
        new()
        {
            Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
            Name = "Росмэн"
        },
        new()
        {
            Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            Name = "Юрайт"
        },
        new()
        {
            Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
            Name = "Инфра-М"
        },
        new()
        {
            Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
            Name = "Флинта"
        },
        new()
        {
            Id = Guid.Parse("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"),
            Name = "Наука"
        }
    ];

    public static List<Reader> Readers =>
    [
        new()
        {
            Id = Guid.Parse("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB"),
            FullName = "Иванов Иван Иванович",
            Address = "ул. Ленина, 1",
            Phone = "+7 999 111 11 11",
            RegistrationDate = new DateTime(2023, 1, 15)
        },
        new()
        {
            Id = Guid.Parse("CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC"),
            FullName = "Петров Пётр Петрович",
            Address = "ул. Пушкина, 25",
            Phone = "+7 999 222 22 22",
            RegistrationDate = new DateTime(2023, 5, 20)
        },
        new()
        {
            Id = Guid.Parse("DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDDDD"),
            FullName = "Сидорова Анна Владимировна",
            Address = "пр. Мира, 15",
            Phone = "+7 999 333 33 33",
            RegistrationDate = new DateTime(2023, 7, 10)
        },
        new()
        {
            Id = Guid.Parse("EEEEEEEE-EEEE-EEEE-EEEE-EEEEEEEEEEEE"),
            FullName = "Кузнецов Дмитрий Сергеевич",
            Address = "ул. Гагарина, 8",
            Phone = "+7 999 444 44 44",
            RegistrationDate = new DateTime(2023, 3, 5)
        },
        new()
        {
            Id = Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"),
            FullName = "Попова Мария Андреевна",
            Address = "ул. Советская, 45",
            Phone = "+7 999 555 55 55",
            RegistrationDate = new DateTime(2023, 9, 12)
        },
        new()
        {
            Id = Guid.Parse("01234567-89AB-CDEF-0123-456789ABCDEF"),
            FullName = "Волков Николай Игоревич",
            Address = "ул. Кирова, 12",
            Phone = "+7 999 666 66 66",
            RegistrationDate = new DateTime(2023, 6, 8)
        },
        new()
        {
            Id = Guid.Parse("12345678-9ABC-DEF0-1234-56789ABCDEF0"),
            FullName = "Фёдорова Дарья Олеговна",
            Address = "пр. Ленинградский, 30",
            Phone = "+7 999 777 77 77",
            RegistrationDate = new DateTime(2023, 4, 18)
        },
        new()
        {
            Id = Guid.Parse("23456789-ABCD-EF01-2345-6789ABCDEF01"),
            FullName = "Егоров Андрей Викторович",
            Address = "ул. Садовая, 5",
            Phone = "+7 999 888 88 88",
            RegistrationDate = new DateTime(2023, 11, 3)
        },
        new()
        {
            Id = Guid.Parse("3456789A-BCDE-F012-3456-789ABCDEF012"),
            FullName = "Смирнова Полина Дмитриевна",
            Address = "ул. Центральная, 18",
            Phone = "+7 999 999 99 99",
            RegistrationDate = new DateTime(2023, 8, 22)
        },
        new()
        {
            Id = Guid.Parse("456789AB-CDEF-0123-4567-89ABCDEF0123"),
            FullName = "Орлова Елена Сергеевна",
            Address = "ул. Молодёжная, 22",
            Phone = "+7 900 123 45 67",
            RegistrationDate = new DateTime(2023, 10, 30)
        }
    ];

    public static List<Book> Books =>
    [
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000001"),
            InventoryNumber = "LIB001",
            CatalogCode = "FIC001",
            Author = "А.С. Пушкин",
            Title = "Евгений Онегин",
            EditionType = EditionType.Hardcover,
            Publisher = Publishers[0],
            PublisherId = Publishers[0].Id,
            PublicationYear = 2020
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000002"),
            InventoryNumber = "LIB002",
            CatalogCode = "FIC002",
            Author = "Л.Н. Толстой",
            Title = "Война и мир",
            EditionType = EditionType.Hardcover,
            Publisher = Publishers[1],
            PublisherId = Publishers[1].Id,
            PublicationYear = 2019
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000003"),
            InventoryNumber = "LIB003",
            CatalogCode = "SCI001",
            Author = "С. Хокинг",
            Title = "Краткая история времени",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[2],
            PublisherId = Publishers[2].Id,
            PublicationYear = 2021
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000004"),
            InventoryNumber = "LIB004",
            CatalogCode = "FIC003",
            Author = "Ф.М. Достоевский",
            Title = "Преступление и наказание",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[0],
            PublisherId = Publishers[0].Id,
            PublicationYear = 2018
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000005"),
            InventoryNumber = "LIB005",
            CatalogCode = "PRO001",
            Author = "Р. Мартин",
            Title = "Чистый код",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[3],
            PublisherId = Publishers[3].Id,
            PublicationYear = 2022
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000006"),
            InventoryNumber = "LIB006",
            CatalogCode = "FIC004",
            Author = "М.А. Булгаков",
            Title = "Мастер и Маргарита",
            EditionType = EditionType.Hardcover,
            Publisher = Publishers[1],
            PublisherId = Publishers[1].Id,
            PublicationYear = 2020
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000007"),
            InventoryNumber = "LIB007",
            CatalogCode = "SCI002",
            Author = "А. Эйнштейн",
            Title = "Теория относительности",
            EditionType = EditionType.Electronic,
            Publisher = Publishers[4],
            PublisherId = Publishers[4].Id,
            PublicationYear = 2019
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000008"),
            InventoryNumber = "LIB008",
            CatalogCode = "FIC005",
            Author = "Дж. Оруэлл",
            Title = "1984",
            EditionType = EditionType.Paperback,
            Publisher = Publishers[5],
            PublisherId = Publishers[5].Id,
            PublicationYear = 2021
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000009"),
            InventoryNumber = "LIB009",
            CatalogCode = "PRO002",
            Author = "Э. Гамма",
            Title = "Паттерны проектирования",
            EditionType = EditionType.Hardcover,
            Publisher = Publishers[2],
            PublisherId = Publishers[2].Id,
            PublicationYear = 2023
        },
        new()
        {
            Id = Guid.Parse("50000000-0000-0000-0000-000000000010"),
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
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000001"),
            Book = Books[0],
            BookId = Books[0].Id,
            Reader = Readers[0],
            ReaderId = Readers[0].Id,
            IssueDate = new DateTime(2024, 1, 10),
            RentalDays = 14,
            ActualReturnDate = new DateTime(2024, 1, 24)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000002"),
            Book = Books[1],
            BookId = Books[1].Id,
            Reader = Readers[1],
            ReaderId = Readers[1].Id,
            IssueDate = new DateTime(2024, 1, 15),
            RentalDays = 21,
            ActualReturnDate = new DateTime(2024, 2, 5)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000003"),
            Book = Books[2],
            BookId = Books[2].Id,
            Reader = Readers[2],
            ReaderId = Readers[2].Id,
            IssueDate = new DateTime(2024, 2, 1),
            RentalDays = 7,
            ActualReturnDate = new DateTime(2024, 2, 8)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000004"),
            Book = Books[3],
            BookId = Books[3].Id,
            Reader = Readers[3],
            ReaderId = Readers[3].Id,
            IssueDate = new DateTime(2024, 2, 20),
            RentalDays = 30,
            ActualReturnDate = null
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000005"),
            Book = Books[4],
            BookId = Books[4].Id,
            Reader = Readers[4],
            ReaderId = Readers[4].Id,
            IssueDate = new DateTime(2024, 3, 5),
            RentalDays = 10,
            ActualReturnDate = new DateTime(2024, 3, 15)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000006"),
            Book = Books[5],
            BookId = Books[5].Id,
            Reader = Readers[5],
            ReaderId = Readers[5].Id,
            IssueDate = new DateTime(2024, 3, 12),
            RentalDays = 14,
            ActualReturnDate = new DateTime(2024, 3, 26)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000007"),
            Book = Books[6],
            BookId = Books[6].Id,
            Reader = Readers[6],
            ReaderId = Readers[6].Id,
            IssueDate = new DateTime(2024, 3, 25),
            RentalDays = 5,
            ActualReturnDate = new DateTime(2024, 3, 30)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000008"),
            Book = Books[7],
            BookId = Books[7].Id,
            Reader = Readers[7],
            ReaderId = Readers[7].Id,
            IssueDate = new DateTime(2024, 4, 2),
            RentalDays = 7,
            ActualReturnDate = null
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000009"),
            Book = Books[8],
            BookId = Books[8].Id,
            Reader = Readers[8],
            ReaderId = Readers[8].Id,
            IssueDate = new DateTime(2024, 4, 10),
            RentalDays = 21,
            ActualReturnDate = new DateTime(2024, 5, 1)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000010"),
            Book = Books[9],
            BookId = Books[9].Id,
            Reader = Readers[9],
            ReaderId = Readers[9].Id,
            IssueDate = new DateTime(2024, 4, 15),
            RentalDays = 10,
            ActualReturnDate = new DateTime(2024, 4, 25)
        },
        // Дополнительные выдачи для статистики
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000011"),
            Book = Books[0],
            BookId = Books[0].Id,
            Reader = Readers[0],
            ReaderId = Readers[0].Id,
            IssueDate = new DateTime(2023, 12, 1),
            RentalDays = 10,
            ActualReturnDate = new DateTime(2023, 12, 11)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000012"),
            Book = Books[1],
            BookId = Books[1].Id,
            Reader = Readers[0],
            ReaderId = Readers[0].Id,
            IssueDate = new DateTime(2023, 11, 15),
            RentalDays = 15,
            ActualReturnDate = new DateTime(2023, 11, 30)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000013"),
            Book = Books[2],
            BookId = Books[2].Id,
            Reader = Readers[1],
            ReaderId = Readers[1].Id,
            IssueDate = new DateTime(2023, 10, 20),
            RentalDays = 20,
            ActualReturnDate = new DateTime(2023, 11, 9)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000014"),
            Book = Books[3],
            BookId = Books[3].Id,
            Reader = Readers[1],
            ReaderId = Readers[1].Id,
            IssueDate = new DateTime(2024, 1, 5),
            RentalDays = 25,
            ActualReturnDate = new DateTime(2024, 1, 30)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000015"),
            Book = Books[4],
            BookId = Books[4].Id,
            Reader = Readers[2],
            ReaderId = Readers[2].Id,
            IssueDate = new DateTime(2023, 9, 1),
            RentalDays = 30,
            ActualReturnDate = new DateTime(2023, 10, 1)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000016"),
            Book = Books[5],
            BookId = Books[5].Id,
            Reader = Readers[2],
            ReaderId = Readers[2].Id,
            IssueDate = new DateTime(2023, 8, 10),
            RentalDays = 12,
            ActualReturnDate = new DateTime(2023, 8, 22)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000017"),
            Book = Books[6],
            BookId = Books[6].Id,
            Reader = Readers[3],
            ReaderId = Readers[3].Id,
            IssueDate = new DateTime(2023, 7, 5),
            RentalDays = 8,
            ActualReturnDate = new DateTime(2023, 7, 13)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000018"),
            Book = Books[7],
            BookId = Books[7].Id,
            Reader = Readers[4],
            ReaderId = Readers[4].Id,
            IssueDate = new DateTime(2023, 6, 20),
            RentalDays = 18,
            ActualReturnDate = new DateTime(2023, 7, 8)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000019"),
            Book = Books[8],
            BookId = Books[8].Id,
            Reader = Readers[5],
            ReaderId = Readers[5].Id,
            IssueDate = new DateTime(2023, 5, 15),
            RentalDays = 22,
            ActualReturnDate = new DateTime(2023, 6, 6)
        },
        new()
        {
            Id = Guid.Parse("60000000-0000-0000-0000-000000000020"),
            Book = Books[9],
            BookId = Books[9].Id,
            Reader = Readers[6],
            ReaderId = Readers[6].Id,
            IssueDate = new DateTime(2023, 4, 1),
            RentalDays = 5,
            ActualReturnDate = new DateTime(2023, 4, 6)
        }
    ];
}