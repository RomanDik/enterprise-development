namespace Library.Application.Contracts.Publishers;

/// <summary>
/// DTO для создания или обновления сущности Publisher
/// </summary>
/// <param name="Name">Название издательства</param>
/// <param name="ContactInfo">Контактная информация издательства</param>
/// <param name="Website">Веб сайт издательства</param>
public record PublisherCreateUpdateDto(
    string Name,
    string? ContactInfo,
    string? Website
);