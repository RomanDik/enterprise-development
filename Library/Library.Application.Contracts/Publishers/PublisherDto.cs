namespace Library.Application.Contracts.Publishers;

/// <summary>
/// DTO для получения сущности Publisher
/// </summary>
/// <param name="Id">Уникальный идентификатор издательства</param>
/// <param name="Name">Название издательства</param>
/// <param name="ContactInfo">Контактная информация издательства</param>
/// <param name="Website">Веб сайт издательства</param>
public record PublisherDto(
    Guid Id,
    string Name,
    string? ContactInfo,
    string? Website
);