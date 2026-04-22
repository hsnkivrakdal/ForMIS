using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormService : IDatabaseServiceImplementation<FormDto, Form>
{
    public FormService(IDatabaseRepository<Form> repository) : base(repository)
    {
    }
}