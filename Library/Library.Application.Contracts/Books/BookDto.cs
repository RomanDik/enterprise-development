using Library.Enums;

namespace Library.Application.Contracts.Books;

/// <summary>
/// DTO для получения сущности Book
/// </summary>
/// <param name="Id">Уникальный идентификатор книги</param>
/// <param name="InventoryNumber">Инвентарный номер книги</param>
/// <param name="CatalogCode">Шифр в алфавитном каталоге</param>
/// <param name="Author">Инициалы и фамилии авторов</param>
/// <param name="Title">Название книги</param>
/// <param name="EditionType">Вид издания</param>
/// <param name="PublisherId">Идентификатор издательства</param>
/// <param name="PublicationYear">Год издания</param>
/// <param name="Status">Статус книги</param>
/// <param name="CreatedDate">Дата создания записи о книге</param>
public record BookDto(
    Guid Id,
    string InventoryNumber,
    string CatalogCode,
    string Author,
    string Title,
    EditionType EditionType,
    Guid PublisherId,
    int PublicationYear,
    BookStatus Status,
    DateTime CreatedDate
);