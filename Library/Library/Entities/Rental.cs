using Library.Enums;

namespace Library.Entities;

/// <summary>
/// Представляет выдачу книги читателю
/// </summary>
public class Rental
{
    /// <summary>
    /// Уникальный идентификатор выдачи
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Идентификатор выданной книги
    /// </summary>
    public required Guid BookId { get; set; }

    /// <summary>
    /// Выданная книга
    /// </summary>
    public required Book Book { get; set; }

    /// <summary>
    /// Идентификатор читателя
    /// </summary>
    public required Guid ReaderId { get; set; }

    /// <summary>
    /// Читатель, которому выдана книга
    /// </summary>
    public required Reader Reader { get; set; }

    /// <summary>
    /// Дата выдачи книги
    /// </summary>
    public required DateTime IssueDate { get; set; }

    /// <summary>
    /// Количество дней, на которое выдана книга
    /// </summary>
    public required int RentalDays { get; set; }

    /// <summary>
    /// Ожидаемая дата возврата книги
    /// </summary>
    public DateTime ExpectedReturnDate => IssueDate.AddDays(RentalDays);

    /// <summary>
    /// Фактическая дата возврата книги
    /// </summary>
    public DateTime? ActualReturnDate { get; set; }

    /// <summary>
    /// Признак возврата книги
    /// </summary>
    public bool IsReturned => ActualReturnDate.HasValue;

    /// <summary>
    /// Статус выдачи книги
    /// </summary>
    public RentalStatus Status { get; set; } = RentalStatus.Active;
}