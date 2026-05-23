using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class StudentRepository : IDatabaseBusinessRepository<Student>
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }
}