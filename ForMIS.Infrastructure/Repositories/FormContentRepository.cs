using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormContentRepository : IDatabaseBusinessRepository<FormContent>
{
    public FormContentRepository(AppDbContext context) : base(context)
    {
    }
}