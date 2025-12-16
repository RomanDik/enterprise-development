using Library.Domain.Enums;

namespace Library.Application.Contracts.Rentals;

/// <summary>
/// DTO для получения сущности Rental
/// </summary>
/// <param name="Id">Уникальный идентификатор выдачи</param>
/// <param name="BookId">Идентификатор выданной книги</param>
/// <param name="ReaderId">Идентификатор читателя</param>
/// <param name="IssueDate">Дата выдачи книги</param>
/// <param name="RentalDays">Количество дней на которое выдана книга</param>
/// <param name="ActualReturnDate">Фактическая дата возврата книги</param>
/// <param name="Status">Статус выдачи книги</param>
public record RentalDto(
    Guid Id,
    Guid BookId,
    Guid ReaderId,
    DateTime IssueDate,
    int RentalDays,
    DateTime? ActualReturnDate,
    RentalStatus Status
);