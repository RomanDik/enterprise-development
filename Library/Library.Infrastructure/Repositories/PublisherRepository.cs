using Library.Domain;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для управления сущностью Publisher
/// </summary>
public class PublisherRepository(LibraryDbContext context) : IRepository<Publisher, Guid>
{
    private readonly DbSet<Publisher> _dbSet = context.Publishers;

    /// <summary>
    /// Создание нового издательства
    /// </summary>
    public async Task<Publisher> Create(Publisher entity)
    {
        await _dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Получение издательства по Id
    /// </summary>
    public async Task<Publisher?> Read(Guid entityId)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Id == entityId);
    }

    /// <summary>
    /// Получение всего списка издательств
    /// </summary>
    public async Task<IList<Publisher>> ReadAll()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Обновление существующего издательства
    /// </summary>
    public async Task<Publisher> Update(Publisher entity)
    {
        _dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Удаление издательства по Id
    /// </summary>
    public async Task<bool> Delete(Guid entityId)
    {
        var publisherToRemove = await _dbSet.FirstOrDefaultAsync(p => p.Id == entityId);

        if (publisherToRemove == null)
        {
            return false;
        }

        _dbSet.Remove(publisherToRemove);
        await context.SaveChangesAsync();

        return true;
    }
}