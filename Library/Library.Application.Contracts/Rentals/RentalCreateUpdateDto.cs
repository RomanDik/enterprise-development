using Library.Domain.Enums;

namespace Library.Application.Contracts.Rentals;

/// <summary>
/// DTO для создания или обновления сущности Rental
/// </summary>
/// <param name="BookId">Идентификатор выданной книги</param>
/// <param name="ReaderId">Идентификатор читателя</param>
/// <param name="IssueDate">Дата выдачи книги</param>
/// <param name="RentalDays">Количество дней на которое выдана книга</param>
/// <param name="ActualReturnDate">Фактическая дата возврата книги</param>
/// <param name="Status">Статус выдачи книги</param>
public record RentalCreateUpdateDto(
    Guid BookId,
    Guid ReaderId,
    DateTime IssueDate,
    int RentalDays,
    DateTime? ActualReturnDate,
    RentalStatus Status
);