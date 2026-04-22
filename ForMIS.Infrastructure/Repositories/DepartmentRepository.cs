using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class DepartmentRepository : IDatabaseBusinessRepository<Department>
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }
}