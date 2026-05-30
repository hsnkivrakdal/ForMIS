using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ForMIS.Infrastructure.Repositories;

public class StudentRepository : IDatabaseBusinessRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<StudentDetail?> GetStudentDetailsByIdentityNumber(string identityNumber)
    {
        var query = from prod in _context.Students
            join standing in _context.Standings on prod.StandingId equals standing.Id
            join department in _context.Departments on prod.DepartmentId equals department.Id
            join faculty in _context.Faculties on department.FacultyId equals faculty.Id
            join user in _context.Users on prod.UserId equals user.Id
            join depMember in _context.DepartmentMembers on prod.DepartmentMemberId equals depMember.Id
            where user.IdentityNumber == identityNumber

            select new StudentDetail
            {
                Id = prod.Id,
                FirstName = prod.FirstName,
                LastName = prod.LastName,
                StudentNumber = prod.StudentNumber,
                StandingId = prod.StandingId,
                StandingName = standing.StandingName,
                DepartmentId = prod.DepartmentId,
                DepartmentName = department.DepartmentName,
                FacultyId = department.FacultyId,
                FacultyName = faculty.FacultyName,
                UserId = prod.UserId,
                IdentityNumber = user.IdentityNumber,
                Email = user.Email,
                Phone = user.Phone,
                UserRole = user.UserRole,
                DepartmentMemberId = prod.DepartmentMemberId,
                DepartmentMemberFirstName = depMember.FirstName,
                DepartmentMemberLastName = depMember.LastName,
                DepartmentMemberUserId = depMember.UserId,
                DepartmentMemberTitle = depMember.MemberTitle,
                OverallCompletedEcts = prod.OverallCompletedEcts,
                ProgramCompletedEcts = prod.ProgramCompletedEcts,
                OverallGpa = prod.OverallGpa,
                ProgramGpa = prod.ProgramGpa,
                NumOfSemesters = prod.NumOfSemesters,
                Status = prod.Status,
                Scholarship = prod.Scholarship,
                Signature = prod.Signature,
                Address = prod.Address
            };
        return await query.FirstOrDefaultAsync();
    }
}