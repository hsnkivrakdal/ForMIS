using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormIlisikKesmeDetailsRepository : IDatabaseBusinessRepository<FormIlisikKesmeDetails>
{
    public FormIlisikKesmeDetailsRepository(AppDbContext context) : base(context)
    {
    }
}