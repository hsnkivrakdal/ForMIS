using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormEkSinav44cDetailsService : IDatabaseServiceImplementation<FormEkSinav44cDetailsDto, FormEkSinav44cDetails>
{
    public FormEkSinav44cDetailsService(IDatabaseRepository<FormEkSinav44cDetails> repository) : base(repository)
    {
    }
}