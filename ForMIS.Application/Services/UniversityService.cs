using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class UniversityService : IDatabaseServiceImplementation<UniversityDto, University>
{
    public UniversityService(IDatabaseRepository<University> repository) : base(repository)
    {
    }
}