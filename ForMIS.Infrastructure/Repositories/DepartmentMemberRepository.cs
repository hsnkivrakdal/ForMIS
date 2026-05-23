using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class DepartmentMemberRepository : IDatabaseBusinessRepository<DepartmentMember>
{
    public DepartmentMemberRepository(AppDbContext context) : base(context)
    {
    }
}