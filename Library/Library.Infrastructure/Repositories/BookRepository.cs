using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

/// <summary>
/// Репозиторий для управления сущностью Book
/// </summary>
public class BookRepository(LibraryDbContext context) : IRepository<Book, Guid>
{
    private readonly DbSet<Book> _dbSet = context.Books;

    /// <summary>
    /// Создание новой книги
    /// </summary>
    public async Task<Book> Create(Book entity)
    {
        await _dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Получение книги по Id
    /// </summary>
    public async Task<Book?> Read(Guid entityId)
    {
        return await _dbSet.FirstOrDefaultAsync(b => b.Id == entityId);
    }

    /// <summary>
    /// Получение всего списка книг
    /// </summary>
    public async Task<IList<Book>> ReadAll()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Обновление существующей книги
    /// </summary>
    public async Task<Book> Update(Book entity)
    {
        _dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Удаление книги по Id
    /// </summary>
    public async Task<bool> Delete(Guid entityId)
    {
        var bookToRemove = await _dbSet.FindAsync(entityId);

        if (bookToRemove == null)
        {
            return false;
        }

        _dbSet.Remove(bookToRemove);
        await context.SaveChangesAsync();

        return true;
    }
}