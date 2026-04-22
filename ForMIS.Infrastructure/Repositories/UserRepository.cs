using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class UserRepository : IDatabaseBusinessRepository<User>
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}