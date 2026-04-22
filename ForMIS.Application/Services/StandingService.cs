using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class StandingService : IDatabaseServiceImplementation<StandingDto, Standing>
{
    public StandingService(IDatabaseRepository<Standing> repository) : base(repository)
    {
    }
}