using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormContentPrecursorRepository : IDatabaseBusinessRepository<FormContentPrecursor>
{
    public FormContentPrecursorRepository(AppDbContext context) : base(context)
    {
    }
}