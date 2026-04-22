using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FacultyService : IDatabaseServiceImplementation<FacultyDto, Faculty>
{
    public FacultyService(IDatabaseRepository<Faculty> repository) : base(repository)
    {
    }
}