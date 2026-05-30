using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Application.Services;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;
using ForMIS.Infrastructure.Persistance;
using ForMIS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ForMIS.FormManagementApi.Extensions;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<FormService>();
        services.AddScoped<IDatabaseService<FormTypeDto,FormType>, FormTypeService>();
        services.AddScoped<IDatabaseService<FormContentDto, FormContent>, FormContentService>();
        services.AddScoped<IDatabaseService<FormContentPrecursorDto, FormContentPrecursor>, FormContentPrecursorService>();
        services.AddScoped<IDatabaseService<FormReviewDto, FormReview>, FormReviewService>();
        services.AddScoped<IDatabaseService<FormStatusDto, FormStatus>, FormStatusService>();
    }

    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IFormRepository, FormRepository>();
        services.AddScoped<IDatabaseRepository<FormType>, FormTypeRepository>();
        services.AddScoped<IDatabaseRepository<FormContent>, FormContentRepository>();
        services.AddScoped<IDatabaseRepository<FormContentPrecursor>, FormContentPrecursorRepository>();
        services.AddScoped<IDatabaseRepository<FormReview>, FormReviewRepository>();
        services.AddScoped<IDatabaseRepository<FormStatus>, FormStatusRepository>();
    }   
}