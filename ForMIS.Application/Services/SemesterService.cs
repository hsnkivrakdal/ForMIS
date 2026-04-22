using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class SemesterService : IDatabaseServiceImplementation<SemesterDto, Semester>
{
    public SemesterService(IDatabaseRepository<Semester> repository) : base(repository)
    {
    }
}