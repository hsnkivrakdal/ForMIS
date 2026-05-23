using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormReviewService : IDatabaseServiceImplementation<FormReviewDto, FormReview>
{
    public FormReviewService(IDatabaseRepository<FormReview> repository) : base(repository)
    {
    }
}