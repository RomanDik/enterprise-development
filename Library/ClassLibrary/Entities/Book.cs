
using Library.Domian.Entities;
using Library.Domian.Enums;

namespace Library.Domian.Entities;

public class Book
{
    public Guid Id { get; set; }

    // Обязательные поля по заданию
    public string InventoryNumber { get; set; } = string.Empty;     // Инвентарный номер
    public string CatalogCode { get; set; } = string.Empty;         // Шифр в алфавитном каталоге
    public string Author { get; set; } = string.Empty;              // Инициалы и фамилии авторов
    public string Title { get; set; } = string.Empty;               // Название

    // Справочники (по заданию)
    public EditionType EditionType { get; set; }                    // Вид издания
    public Guid PublisherId { get; set; }                           // Внешний ключ на издательство
    public Publisher Publisher { get; set; } = null!;               // Навигационное свойство

    public int PublicationYear { get; set; }                        // Год издания

    // Дополнительные поля для функциональности
    public BookStatus Status { get; set; } = BookStatus.Available;  // Статус книги
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;    // Дата создания записи
}