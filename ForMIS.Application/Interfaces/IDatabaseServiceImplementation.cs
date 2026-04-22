using ForMIS.Domain.Interfaces;
using Mapster;

namespace ForMIS.Application.Interfaces;

public class IDatabaseServiceImplementation<TDto, TEntity> : IDatabaseService<TDto, TEntity> where TDto : class where TEntity : class, new()
{

    private readonly IDatabaseRepository<TEntity> _repository;
    
    public IDatabaseServiceImplementation(IDatabaseRepository<TEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task<List<TDto>> GetAllAsync()
    {
        var list = await _repository.GetAllAsync();
        return list.Select(e => e.Adapt<TDto>()).ToList();
    }

    public async Task<TDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity?.Adapt<TDto>();
    }

    public async Task<TDto?> GetByIdAsync(string id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity?.Adapt<TDto>();
    }

    public async Task<TDto> AddAsync(TDto dto)
    {
        var entity = dto.Adapt<TEntity>();
        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();
        return entity.Adapt<TDto>();
    }

    public async Task UpdateAsync(TDto dto)
    {
        var entity = dto.Adapt<TEntity>();
        await _repository.UpdateAsync(entity);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _repository.SaveChangesAsync();
    }
}