using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class SemesterRepository : IDatabaseBusinessRepository<Semester>
{
    public SemesterRepository(AppDbContext context) : base(context)
    {
    }
}