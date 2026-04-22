using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class DepartmentService : IDatabaseServiceImplementation<DepartmentDto, Department>
{
    public DepartmentService(IDatabaseRepository<Department> repository) : base(repository)
    {
    }
}