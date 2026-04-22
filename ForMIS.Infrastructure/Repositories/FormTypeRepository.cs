using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormTypeRepository : IDatabaseBusinessRepository<FormType>
{
    public FormTypeRepository(AppDbContext context) : base(context)
    {
    }
}