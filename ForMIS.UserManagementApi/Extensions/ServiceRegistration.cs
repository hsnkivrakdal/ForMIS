using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Application.Services;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;
using ForMIS.Infrastructure.Persistance;
using ForMIS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ForMIS.UserManagementApi.Extensions;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseService<UniversityDto, University>, UniversityService>();
        services.AddScoped<IDatabaseService<FacultyDto, Faculty>, FacultyService>();
    }

    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IDatabaseRepository<University>, UniversityRepository>();
        services.AddScoped<IDatabaseRepository<Faculty>, FacultyRepository>();
    }
}