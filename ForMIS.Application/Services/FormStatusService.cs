using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormStatusService : IDatabaseServiceImplementation<FormStatusDto, FormStatus>
{
    public FormStatusService(IDatabaseRepository<FormStatus> repository) : base(repository)
    {
    }
}