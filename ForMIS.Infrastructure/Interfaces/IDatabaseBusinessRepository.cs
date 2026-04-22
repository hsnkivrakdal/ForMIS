using ForMIS.Domain.Interfaces;
using ForMIS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ForMIS.Infrastructure.Interfaces;

public class IDatabaseBusinessRepository<TEntity> : IDatabaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public IDatabaseBusinessRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    public async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
    

    public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    public async Task<TEntity?> GetByIdAsync(string id) => await _dbSet.FindAsync(id);

    public async Task AddAsync(TEntity apiary)
    {
        _dbSet.Add(apiary);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity apiary)
    {
        _dbSet.Update(apiary);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}