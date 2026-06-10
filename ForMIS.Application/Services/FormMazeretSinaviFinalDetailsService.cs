using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormMazeretSinaviFinalDetailsService : IDatabaseServiceImplementation<FormMazeretSinaviFinalDetailsDto, FormMazeretSinaviFinalDetails>
{
    public FormMazeretSinaviFinalDetailsService(IDatabaseRepository<FormMazeretSinaviFinalDetails> repository) : base(repository)
    {
    }
}