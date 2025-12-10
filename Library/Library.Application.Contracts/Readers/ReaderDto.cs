namespace Library.Application.Contracts.Readers;

/// <summary>
/// DTO для получения сущности Reader
/// </summary>
/// <param name="Id">Уникальный идентификатор читателя</param>
/// <param name="FullName">Полное имя читателя</param>
/// <param name="Address">Адрес читателя</param>
/// <param name="Phone">Телефон читателя</param>
/// <param name="RegistrationDate">Дата регистрации читателя в библиотеке</param>
/// <param name="Email">Электронная почта читателя</param>
/// <param name="BirthDate">Дата рождения читателя</param>
public record ReaderDto(
    Guid Id,
    string FullName,
    string Address,
    string Phone,
    DateTime RegistrationDate,
    string? Email,
    DateOnly? BirthDate
);