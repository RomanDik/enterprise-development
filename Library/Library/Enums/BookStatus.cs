namespace Library.Enums;

/// <summary>
/// Определяет статусы доступности книг
/// </summary>
public enum BookStatus
{
    /// <summary>
    /// Книга доступна для выдачи
    /// </summary>
    Available,

    /// <summary>
    /// Книга выдана читателю
    /// </summary>
    Rented,

    /// <summary>
    /// Книга зарезервирована
    /// </summary>
    Reserved,

    /// <summary>
    /// Книга на ремонте
    /// </summary>
    UnderRepair,

    /// <summary>
    /// Книга утеряна
    /// </summary>
    Lost
}