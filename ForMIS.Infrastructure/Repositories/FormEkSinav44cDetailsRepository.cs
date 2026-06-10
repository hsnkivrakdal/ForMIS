using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormEkSinav44cDetailsRepository : IDatabaseBusinessRepository<FormEkSinav44cDetails>
{
    public FormEkSinav44cDetailsRepository(AppDbContext context) : base(context)
    {
    }
}