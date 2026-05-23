using ForMIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForMIS.Infrastructure.Persistance;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Form> Forms => Set<Form>();
    public DbSet<FormContent> FormContents => Set<FormContent>();
    public DbSet<FormContentPrecursor> FormContentPrecursors => Set<FormContentPrecursor>();
    public DbSet<FormType> FormTypes => Set<FormType>();
    public DbSet<Semester> Semesters => Set<Semester>();
    public DbSet<Standing> Standings => Set<Standing>();
    public DbSet<University> Universities => Set<University>();
    public DbSet<User> Users => Set<User>();
    public DbSet<DepartmentMember> DepartmentMembers => Set<DepartmentMember>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<FormReview> FormReviews => Set<FormReview>();
    public DbSet<FormStatus> FormStatus => Set<FormStatus>();
}