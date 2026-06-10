using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormEkSinav44cCoursesService : IDatabaseServiceImplementation<FormEkSinav44cCoursesDto, FormEkSinav44cCourses>
{
    public FormEkSinav44cCoursesService(IDatabaseRepository<FormEkSinav44cCourses> repository) : base(repository)
    {
    }
}