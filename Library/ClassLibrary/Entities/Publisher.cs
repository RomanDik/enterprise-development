using Library.Domian.Entities;

namespace Library.Domian.Entities;

public class Publisher
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;                // Название издательства

    // Дополнительные поля
    public string? ContactInfo { get; set; }                        // Контактная информация
    public string? Website { get; set; }                            // Веб-сайт

    // Навигационные свойства
    public List<Book> Books { get; set; } = new();                 // Книги этого издательства
}