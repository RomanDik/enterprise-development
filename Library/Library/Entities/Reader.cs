using Library.Domian.Entities;

namespace Library.Domian.Entities;
/// <summary>
/// Представляет читателя библиотеки
/// </summary>
public class Reader
{
    /// <summary>
    /// Уникальный идентификатор читателя
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Полное имя читателя
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Адрес читателя
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Телефон читателя
    /// </summary>
    public required string Phone { get; set; }

    /// <summary>
    /// Дата регистрации читателя в библиотеке
    /// </summary>
    public required DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Список выданных книг читателю
    /// </summary>
    public List<Rental> Rentals { get; set; } = new();

    /// <summary>
    /// Электронная почта читателя
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Дата рождения читателя
    /// </summary>
    public DateOnly? BirthDate { get; set; }
}