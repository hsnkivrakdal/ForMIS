using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class UniversityRepository : IDatabaseBusinessRepository<University>
{
    public UniversityRepository(AppDbContext context) : base(context)
    {
    }
}