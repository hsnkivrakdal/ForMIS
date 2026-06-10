using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormIlisikKesmeDetailsService : IDatabaseServiceImplementation<FormIlisikKesmeDetailsDto, FormIlisikKesmeDetails>
{
    public FormIlisikKesmeDetailsService(IDatabaseRepository<FormIlisikKesmeDetails> repository) : base(repository)
    {
    }
}
