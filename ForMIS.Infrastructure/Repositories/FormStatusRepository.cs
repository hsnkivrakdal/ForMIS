using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormStatusRepository : IDatabaseBusinessRepository<FormStatus>
{
    public FormStatusRepository(AppDbContext context) : base(context)
    {
    }
}