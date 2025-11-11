using Library.Domian.Entities;

namespace Library.Domian.Entities;

public class Reader
{
    public Guid Id { get; set; }

    // Обязательные поля по заданию
    public string FullName { get; set; } = string.Empty;            // ФИО
    public string Address { get; set; } = string.Empty;             // Адрес
    public string Phone { get; set; } = string.Empty;               // Телефон
    public DateTime RegistrationDate { get; set; }                  // Дата регистрации

    // Навигационные свойства
    public List<Rental> Rentals { get; set; } = new();             // Выданные книги

    // Дополнительные поля
    public string Email { get; set; } = string.Empty;               // Email (опционально)
    public DateTime? BirthDate { get; set; }                        // Дата рождения (опционально)
}