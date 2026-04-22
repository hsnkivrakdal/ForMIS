namespace ForMIS.Application.Interfaces;

public interface IDatabaseService<TDto, TEntity> where TDto : class where TEntity : class
{
    Task<List<TDto>> GetAllAsync();
    Task<TDto?> GetByIdAsync(int id);
    Task<TDto?> GetByIdAsync(string id);
    Task<TDto> AddAsync(TDto dto);
    Task UpdateAsync(TDto dto);
    Task DeleteAsync(int id);
}