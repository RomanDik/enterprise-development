using Library.Domian.Entities;

namespace Library.Domian.Entities;

/// <summary>
/// Представляет издательство (справочник)
/// </summary>
public class Publisher
{
    /// <summary>
    /// Уникальный идентификатор издательства
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название издательства
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Контактная информация издательства
    /// </summary>
    public string? ContactInfo { get; set; }

    /// <summary>
    /// Веб-сайт издательства
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Список книг этого издательства
    /// </summary>
    public List<Book> Books { get; set; } = new();
}