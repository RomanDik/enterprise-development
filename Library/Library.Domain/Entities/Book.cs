using Library.Domain.Enums;

namespace Library.Domain.Entities;

/// <summary>
/// Представляет книгу в библиотечной системе
/// </summary>
public class Book
{
    /// <summary>
    /// Уникальный идентификатор книги
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Инвентарный номер книги
    /// </summary>
    public required string InventoryNumber { get; set; }

    /// <summary>
    /// Шифр в алфавитном каталоге
    /// </summary>
    public required string CatalogCode { get; set; }

    /// <summary>
    /// Инициалы и фамилии авторов
    /// </summary>
    public required string Author { get; set; }

    /// <summary>
    /// Название книги
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Вид издания (справочник)
    /// </summary>
    public required EditionType EditionType { get; set; }

    /// <summary>
    /// Идентификатор издательства
    /// </summary>
    public required Guid PublisherId { get; set; }

    /// <summary>
    /// Издательство (справочник)
    /// </summary>
    public required Publisher Publisher { get; set; }

    /// <summary>
    /// Год издания
    /// </summary>
    public required int PublicationYear { get; set; }

    /// <summary>
    /// Статус книги (доступна, выдана и т.д.)
    /// </summary>
    public BookStatus Status { get; set; } = BookStatus.Available;

    /// <summary>
    /// Дата создания записи о книге
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}