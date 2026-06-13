using ErtisAuth.Extensions.AspNetCore.Extensions;
using ForMIS.UniversityManagementApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddErtisAuth();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        policy => { policy.WithOrigins(
            "http://localhost:3000").AllowAnyMethod().AllowAnyHeader(); });
});

var app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowLocalhost3000");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();