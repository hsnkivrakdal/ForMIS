using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class FormService : IDatabaseServiceImplementation<FormDto, Form>
{
    private readonly IFormRepository _repository;
    public FormService(IFormRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<List<FormDetailsDto>> GetFormDetailsByStudentNumber(string studentNumber)
    {
        var list = await _repository.GetFormDetailsByStudentNumber(studentNumber);
        return list.Select(Map).ToList();
    }

    public async Task<FormDetailsDto?> GetFormDetailsById(int id)
    {
        var d = await _repository.GetFormDetailsById(id);
        return d == null ? null : Map(d);
    }

    private static FormDetailsDto Map(FormDetail d) => new FormDetailsDto
    {
        Id = d.Id,
        FormTypeId = d.FormTypeId,
        FormTypeName = d.FormTypeName,
        LayoutKey = d.LayoutKey,
        SemesterId = d.SemesterId,
        SemesterName = d.SemesterName,
        FormContentId = d.FormContentId,
        FormStatusId = d.FormStatusId,
        FormStatusName = d.FormStatusName,
        StudentId = d.StudentId,
        AdvisorId = d.AdvisorId,
        StudentNumber = d.StudentNumber,
        StudentName = d.StudentName,
        StudentSurname = d.StudentSurname,
        StudentPhone = d.StudentPhone,
        StudentEmail = d.StudentEmail,
        StudentFaculty = d.StudentFaculty,
        StudentGpa = d.StudentGpa,
        StudentDepartment = d.StudentDepartment,
        NumOfSemesters = d.NumOfSemesters,
        FormDate = d.FormDate,
        ScholarshipStatus = d.ScholarshipStatus,
        StudentAddress = d.StudentAddress,
        StudentSignature = d.StudentSignature
    };
}