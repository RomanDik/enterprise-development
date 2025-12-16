using AutoMapper;
using Library.Application.Contracts;
using Library.Application.Contracts.Readers;
using Library.Domain;
using Library.Domain.Entities;

namespace Library.Application.Services;

/// <summary>
/// Сервис приложения для CRUD операций с читателями
/// </summary>
public class ReaderAppService(IRepository<Reader, Guid> repository, IMapper mapper)
    : IApplicationService<ReaderDto, ReaderCreateUpdateDto, Guid>
{
    /// <summary>
    /// Создаёт читателя на основе DTO для создания или обновления
    /// </summary>
    /// <param name="dto">DTO для создания или обновления читателя</param>
    /// <returns>DTO для получения созданного читателя</returns>
    public async Task<ReaderDto> Create(ReaderCreateUpdateDto dto)
    {
        var entity = mapper.Map<Reader>(dto);
        entity.Id = Guid.NewGuid();

        var created = await repository.Create(entity);
        return mapper.Map<ReaderDto>(created);
    }

    /// <summary>
    /// Получает читателя по идентификатору
    /// </summary>
    /// <param name="dtoId">Идентификатор читателя</param>
    /// <returns>DTO для получения читателя или null если читатель не найден</returns>
    public async Task<ReaderDto?> Get(Guid dtoId)
    {
        var entity = await repository.Read(dtoId);
        return mapper.Map<ReaderDto>(entity);
    }

    /// <summary>
    /// Получает список всех читателей
    /// </summary>
    /// <returns>Список DTO для получения читателей</returns>
    public async Task<IList<ReaderDto>> GetAll()
    {
        var entities = await repository.ReadAll();
        return [.. entities.Select(mapper.Map<ReaderDto>)];
    }

    /// <summary>
    /// Обновляет читателя по идентификатору на основе DTO для создания или обновления
    /// </summary>
    /// <param name="dto">DTO для создания или обновления читателя</param>
    /// <param name="dtoId">Идентификатор читателя</param>
    /// <returns>DTO для получения обновлённого читателя</returns>
    public async Task<ReaderDto> Update(ReaderCreateUpdateDto dto, Guid dtoId)
    {
        var existing = await repository.Read(dtoId) ?? throw new KeyNotFoundException("Читатель не найден");
        mapper.Map(dto, existing);

        var updated = await repository.Update(existing);
        return mapper.Map<ReaderDto>(updated);
    }

    /// <summary>
    /// Удаляет читателя по идентификатору
    /// </summary>
    /// <param name="dtoId">Идентификатор читателя</param>
    /// <returns>true если читатель удалён иначе false</returns>
    public Task<bool> Delete(Guid dtoId) => repository.Delete(dtoId);
}