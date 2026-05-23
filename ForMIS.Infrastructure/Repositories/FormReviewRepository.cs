using ForMIS.Application.DTOs;
using ForMIS.Domain.Entities;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;

namespace ForMIS.Infrastructure.Repositories;

public class FormReviewRepository : IDatabaseBusinessRepository<FormReview>
{
    public FormReviewRepository(AppDbContext context) : base(context)
    {
    }
}