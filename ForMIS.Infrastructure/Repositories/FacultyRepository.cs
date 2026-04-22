using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FacultyRepository : IDatabaseBusinessRepository<Faculty>
{
    public FacultyRepository(AppDbContext context) : base(context)
    {
    }
}