using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormContentService : IDatabaseServiceImplementation<FormContentDto, FormContent>
{
    public FormContentService(IDatabaseRepository<FormContent> repository) : base(repository)
    {
    }
}