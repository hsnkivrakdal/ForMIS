using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormMazeretSinaviFinalDetailsRepository : IDatabaseBusinessRepository<FormMazeretSinaviFinalDetails>
{
    public FormMazeretSinaviFinalDetailsRepository(AppDbContext context) : base(context)
    {
    }
}