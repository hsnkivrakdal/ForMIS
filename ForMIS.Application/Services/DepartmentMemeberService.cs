using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class DepartmentMemeberService : IDatabaseServiceImplementation<DepartmentMemberDto, DepartmentMember>
{
    public DepartmentMemeberService(IDatabaseRepository<DepartmentMember> repository) : base(repository)
    {
    }
}