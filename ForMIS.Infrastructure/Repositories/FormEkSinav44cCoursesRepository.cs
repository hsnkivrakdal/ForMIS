using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormEkSinav44cCoursesRepository : IDatabaseBusinessRepository<FormEkSinav44cCourses>
{
    public FormEkSinav44cCoursesRepository(AppDbContext context) : base(context)
    {
    }
}