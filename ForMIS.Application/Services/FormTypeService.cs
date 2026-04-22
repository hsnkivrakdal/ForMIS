using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormTypeService : IDatabaseServiceImplementation<FormTypeDto, FormType>
{
    public FormTypeService(IDatabaseRepository<FormType> repository) : base(repository)
    {
    }
}