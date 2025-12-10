using AutoMapper;
using Library.Application.Contracts;
using Library.Application.Contracts.Rentals;
using Library.Entities;

namespace Library.Application.Services;

/// <summary>
/// Сервис приложения для CRUD операций с выдачами
/// </summary>
public class RentalAppService(IRepository<Rental, Guid> repository, IMapper mapper)
    : IApplicationService<RentalDto, RentalCreateUpdateDto, Guid>
{
    /// <summary>
    /// Создаёт выдачу на основе DTO для создания или обновления
    /// </summary>
    /// <param name="dto">DTO для создания или обновления выдачи</param>
    /// <returns>DTO для получения созданной выдачи</returns>
    public async Task<RentalDto> Create(RentalCreateUpdateDto dto)
    {
        var entity = mapper.Map<Rental>(dto);
        entity.Id = Guid.NewGuid();

        var created = await repository.Create(entity);
        return mapper.Map<RentalDto>(created);
    }

    /// <summary>
    /// Получает выдачу по идентификатору
    /// </summary>
    /// <param name="dtoId">Идентификатор выдачи</param>
    /// <returns>DTO для получения выдачи или null если выдача не найдена</returns>
    public async Task<RentalDto?> Get(Guid dtoId)
    {
        var entity = await repository.Read(dtoId);
        return mapper.Map<RentalDto>(entity);
    }

    /// <summary>
    /// Получает список всех выдач
    /// </summary>
    /// <returns>Список DTO для получения выдач</returns>
    public async Task<IList<RentalDto>> GetAll()
    {
        var entities = await repository.ReadAll();
        return [.. entities.Select(mapper.Map<RentalDto>)];
    }

    /// <summary>
    /// Обновляет выдачу по идентификатору на основе DTO для создания или обновления
    /// </summary>
    /// <param name="dto">DTO для создания или обновления выдачи</param>
    /// <param name="dtoId">Идентификатор выдачи</param>
    /// <returns>DTO для получения обновлённой выдачи</returns>
    public async Task<RentalDto> Update(RentalCreateUpdateDto dto, Guid dtoId)
    {
        var existing = await repository.Read(dtoId) ?? throw new KeyNotFoundException("Выдача не найдена");
        mapper.Map(dto, existing);

        var updated = await repository.Update(existing);
        return mapper.Map<RentalDto>(updated);
    }

    /// <summary>
    /// Удаляет выдачу по идентификатору
    /// </summary>
    /// <param name="dtoId">Идентификатор выдачи</param>
    /// <returns>true если выдача удалена иначе false</returns>
    public Task<bool> Delete(Guid dtoId) => repository.Delete(dtoId);
}