using AutoMapper;
using Library.Application.Contracts;
using Library.Application.Contracts.Publishers;
using Library.Entities;

namespace Library.Application.Services;

/// <summary>
/// Сервис приложения для CRUD операций с издательствами
/// </summary>
public class PublisherAppService(IRepository<Publisher, Guid> repository, IMapper mapper)
    : IApplicationService<PublisherDto, PublisherCreateUpdateDto, Guid>
{
    /// <summary>
    /// Создаёт издательство на основе DTO для создания или обновления
    /// </summary>
    /// <param name="dto">DTO для создания или обновления издательства</param>
    /// <returns>DTO для получения созданного издательства</returns>
    public async Task<PublisherDto> Create(PublisherCreateUpdateDto dto)
    {
        var entity = mapper.Map<Publisher>(dto);
        entity.Id = Guid.NewGuid();

        var created = await repository.Create(entity);
        return mapper.Map<PublisherDto>(created);
    }

    /// <summary>
    /// Получает издательство по идентификатору
    /// </summary>
    /// <param name="dtoId">Идентификатор издательства</param>
    /// <returns>DTO для получения издательства или null если издательство не найдено</returns>
    public async Task<PublisherDto?> Get(Guid dtoId)
    {
        var entity = await repository.Read(dtoId);
        return mapper.Map<PublisherDto>(entity);
    }

    /// <summary>
    /// Получает список всех издательств
    /// </summary>
    /// <returns>Список DTO для получения издательств</returns>
    public async Task<IList<PublisherDto>> GetAll()
    {
        var entities = await repository.ReadAll();
        return [.. entities.Select(mapper.Map<PublisherDto>)];
    }

    /// <summary>
    /// Обновляет издательство по идентификатору на основе DTO для создания или обновления
    /// </summary>
    /// <param name="dto">DTO для создания или обновления издательства</param>
    /// <param name="dtoId">Идентификатор издательства</param>
    /// <returns>DTO для получения обновлённого издательства</returns>
    public async Task<PublisherDto> Update(PublisherCreateUpdateDto dto, Guid dtoId)
    {
        var existing = await repository.Read(dtoId) ?? throw new KeyNotFoundException("Издательство не найдено");
        mapper.Map(dto, existing);

        var updated = await repository.Update(existing);
        return mapper.Map<PublisherDto>(updated);
    }

    /// <summary>
    /// Удаляет издательство по идентификатору
    /// </summary>
    /// <param name="dtoId">Идентификатор издательства</param>
    /// <returns>true если издательство удалено иначе false</returns>
    public Task<bool> Delete(Guid dtoId) => repository.Delete(dtoId);
}