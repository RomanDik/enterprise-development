using Library.Domian.Entities;
using Library.Domian.Enums;

namespace Library.Domian.Entities;

public class Rental
{
    public Guid Id { get; set; }

    // Связи
    public Guid BookId { get; set; }                                // Внешний ключ на книгу
    public Book Book { get; set; } = null!;                         // Навигационное свойство

    public Guid ReaderId { get; set; }                              // Внешний ключ на читателя
    public Reader Reader { get; set; } = null!;                     // Навигационное свойство

    // Обязательные поля по заданию
    public DateTime IssueDate { get; set; }                         // Дата выдачи
    public int RentalDays { get; set; }                             // Количество дней выдачи

    // Дополнительные поля для функциональности
    public DateTime ExpectedReturnDate => IssueDate.AddDays(RentalDays);  // Ожидаемая дата возврата
    public DateTime? ActualReturnDate { get; set; }                 // Фактическая дата возврата
    public bool IsReturned => ActualReturnDate.HasValue;            // Возвращена ли книга

    // Статус выдачи
    public RentalStatus Status { get; set; } = RentalStatus.Active;
}