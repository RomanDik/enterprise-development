namespace Library.Domain.Enums;

/// <summary>
/// Определяет статусы выдачи книг
/// </summary>
public enum RentalStatus
{
    /// <summary>
    /// Активная выдача (книга не возвращена)
    /// </summary>
    Active,

    /// <summary>
    /// Книга возвращена
    /// </summary>
    Returned,

    /// <summary>
    /// Выдача просрочена
    /// </summary>
    Overdue,

    /// <summary>
    /// Книга утеряна читателем
    /// </summary>
    Lost
}