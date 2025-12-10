using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для управления сущностью Rental
/// </summary>
public class RentalRepository(LibraryDbContext context) : IRepository<Rental, Guid>
{
    private readonly DbSet<Rental> _dbSet = context.Rentals;

    /// <summary>
    /// Создание новой выдачи
    /// </summary>
    public async Task<Rental> Create(Rental entity)
    {
        await _dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Получение выдачи по Id
    /// </summary>
    public async Task<Rental?> Read(Guid entityId)
    {
        return await _dbSet.FirstOrDefaultAsync(r => r.Id == entityId);
    }

    /// <summary>
    /// Получение всего списка выдач
    /// </summary>
    public async Task<IList<Rental>> ReadAll()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Обновление существующей выдачи
    /// </summary>
    public async Task<Rental> Update(Rental entity)
    {
        _dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Удаление выдачи по Id
    /// </summary>
    public async Task<bool> Delete(Guid entityId)
    {
        var rentalToRemove = await _dbSet.FirstOrDefaultAsync(r => r.Id == entityId);

        if (rentalToRemove == null)
        {
            return false;
        }

        _dbSet.Remove(rentalToRemove);
        await context.SaveChangesAsync();

        return true;
    }
}