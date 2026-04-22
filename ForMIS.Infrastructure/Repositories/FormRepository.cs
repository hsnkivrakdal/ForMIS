using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormRepository : IDatabaseBusinessRepository<Form>
{
    public FormRepository(AppDbContext context) : base(context)
    {
    }
}