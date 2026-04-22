using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormContentPrecursorService : IDatabaseServiceImplementation<FormContentPrecursorDto, FormContentPrecursor>
{
    public FormContentPrecursorService(IDatabaseRepository<FormContentPrecursor> repository) : base(repository)
    {
    }
}