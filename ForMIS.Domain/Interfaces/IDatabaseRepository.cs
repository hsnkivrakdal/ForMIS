namespace ForMIS.Domain.Interfaces;

public interface IDatabaseRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity?> GetByIdAsync(string id);
    Task AddAsync(TEntity apiary);
    Task UpdateAsync(TEntity apiary);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}