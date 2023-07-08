using System.Linq.Expressions;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly BookStoreDbContext _dbContext;
    protected readonly DbSet<TEntity> DbSet;

    protected Repository(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }
    
    public void Dispose()
    {
        _dbContext?.Dispose();
    }

    public virtual async Task Add(TEntity entity)
    {
        DbSet.Add(entity: entity);
        await SaveChanges();
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task Update(TEntity entity)
    {
        DbSet.Update(entity: entity);
        await SaveChanges();
    }

    public virtual async Task Remove(TEntity entity)
    {
        DbSet.Remove(entity: entity);
        await SaveChanges();
    }

    public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<int> SaveChanges()
    {
        return await _dbContext.SaveChangesAsync();
    }
}