using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class StudentService : IDatabaseServiceImplementation<StudentDto, Student>
{
    private readonly IStudentRepository _repository;
    public StudentService(IStudentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<StudentDetailsDto?> GetStudentDetailsByIdentityNumber(string identityNumber)
    {
        var d = await _repository.GetStudentDetailsByIdentityNumber(identityNumber);

        if (d == null)
            return null;

        return new StudentDetailsDto
        {
            Id = d.Id,
            FirstName = d.FirstName,
            LastName = d.LastName,
            StudentNumber = d.StudentNumber,
            StandingId = d.StandingId,
            StandingName = d.StandingName,
            DepartmentId = d.DepartmentId,
            DepartmentName = d.DepartmentName,
            FacultyId = d.FacultyId,
            FacultyName = d.FacultyName,
            UserId = d.UserId,
            IdentityNumber = d.IdentityNumber,
            Email = d.Email,
            Phone = d.Phone,
            UserRole = d.UserRole,
            DepartmentMemberId = d.DepartmentMemberId,
            DepartmentMemberFirstName = d.DepartmentMemberFirstName,
            DepartmentMemberLastName = d.DepartmentMemberLastName,
            DepartmentMemberUserId = d.DepartmentMemberUserId,
            DepartmentMemberTitle = d.DepartmentMemberTitle,
            OverallCompletedEcts = d.OverallCompletedEcts,
            ProgramCompletedEcts = d.ProgramCompletedEcts,
            OverallGpa = d.OverallGpa,
            
            ProgramGpa = d.ProgramGpa,
            NumOfSemesters = d.NumOfSemesters,
            Status = d.Status,
            Scholarship = d.Scholarship,
            Address = d.Address,
            Signature = d.Signature
        };
    }
}