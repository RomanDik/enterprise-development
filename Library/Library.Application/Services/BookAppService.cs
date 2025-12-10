using AutoMapper;
using Library.Application.Contracts;
using Library.Application.Contracts.Books;
using Library.Entities;

namespace Library.Application.Services;

/// <summary>
/// Сервис приложения для CRUD операций с книгами
/// </summary>
public class BookAppService(IRepository<Book, Guid> repository, IMapper mapper)
    : IApplicationService<BookDto, BookCreateUpdateDto, Guid>
{
    /// <summary>
    /// Создаёт книгу на основе DTO для создания или обновления
    /// </summary>
    /// <param name="dto">DTO для создания или обновления книги</param>
    /// <returns>DTO для получения созданной книги</returns>
    public async Task<BookDto> Create(BookCreateUpdateDto dto)
    {
        var entity = mapper.Map<Book>(dto);
        entity.Id = Guid.NewGuid();

        var created = await repository.Create(entity);
        return mapper.Map<BookDto>(created);
    }

    /// <summary>
    /// Получает книгу по идентификатору
    /// </summary>
    /// <param name="dtoId">Идентификатор книги</param>
    /// <returns>DTO для получения книги или null если книга не найдена</returns>
    public async Task<BookDto?> Get(Guid dtoId)
    {
        var entity = await repository.Read(dtoId);
        return mapper.Map<BookDto>(entity);
    }

    /// <summary>
    /// Получает список всех книг
    /// </summary>
    /// <returns>Список DTO для получения книг</returns>
    public async Task<IList<BookDto>> GetAll()
    {
        var entities = await repository.ReadAll();
        return [.. entities.Select(mapper.Map<BookDto>)];
    }

    /// <summary>
    /// Обновляет книгу по идентификатору на основе DTO для создания или обновления
    /// </summary>
    /// <param name="dto">DTO для создания или обновления книги</param>
    /// <param name="dtoId">Идентификатор книги</param>
    /// <returns>DTO для получения обновлённой книги</returns>
    public async Task<BookDto> Update(BookCreateUpdateDto dto, Guid dtoId)
    {
        var existing = await repository.Read(dtoId) ?? throw new KeyNotFoundException("Книга не найдена");
        mapper.Map(dto, existing);

        var updated = await repository.Update(existing);
        return mapper.Map<BookDto>(updated);
    }

    /// <summary>
    /// Удаляет книгу по идентификатору
    /// </summary>
    /// <param name="dtoId">Идентификатор книги</param>
    /// <returns>true если книга удалена иначе false</returns>
    public Task<bool> Delete(Guid dtoId) => repository.Delete(dtoId);
}