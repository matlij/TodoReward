using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using TodoReward.Core.Interfaces;
using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Repositories;

public class LocalDbRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    private readonly DbContextOptionsBuilder<MyDbContext> _optionsBuilder;

    public LocalDbRepository(IOptions<DbContextOptionsBuilder<MyDbContext>> optionsBuilder)
    {
        _optionsBuilder = optionsBuilder.Value;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var ctx = new MyDbContext(_optionsBuilder.Options);

        return await ctx.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        using var ctx = new MyDbContext(_optionsBuilder.Options);

        return await ctx.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<T>> GetBySpecificationAsync(Expression<Func<T, bool>> predicate)
    {
        using var ctx = new MyDbContext(_optionsBuilder.Options);

        return await ctx.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<bool> AddAsync(T item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        using var ctx = new MyDbContext(_optionsBuilder.Options);

        await ctx.Set<T>().AddAsync(item);
        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var ctx = new MyDbContext(_optionsBuilder.Options);

        var entityToDelete = await ctx.Set<T>().FindAsync(id);
        if (entityToDelete is null)
            return false;

        ctx.Set<T>().Remove(entityToDelete);

        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Guid id, T item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        using var ctx = new MyDbContext(_optionsBuilder.Options);

        ctx.Update(item);

        return await ctx.SaveChangesAsync() > 0;
    }
}