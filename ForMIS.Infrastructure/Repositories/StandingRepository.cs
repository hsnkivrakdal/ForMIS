using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class StandingRepository : IDatabaseBusinessRepository<Standing>
{
    public StandingRepository(AppDbContext context) : base(context)
    {
    }
}