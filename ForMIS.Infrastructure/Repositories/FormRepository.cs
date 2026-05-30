using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;
using ForMIS.Infrastructure.Interfaces;
using ForMIS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ForMIS.Infrastructure.Repositories;

public class FormRepository : IDatabaseBusinessRepository<Form>, IFormRepository
{
    public FormRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<FormDetail>> GetFormDetailsByStudentId(int studentId)
    {
        var query = BuildFormDetailQuery().Where(f => f.StudentId == studentId);
        return await query.ToListAsync();
    }

    public async Task<FormDetail?> GetFormDetailsById(int id)
    {
        var query = BuildFormDetailQuery().Where(f => f.Id == id);
        return await query.FirstOrDefaultAsync();
    }

    private IQueryable<FormDetail> BuildFormDetailQuery()
    {
        return from form in _context.Forms
            join formType in _context.FormTypes on form.FormTypeId equals formType.Id
            join formStatus in _context.FormStatus on form.FormStatusId equals formStatus.Id
            join semester in _context.Semesters on form.SemesterId equals semester.Id
            select new FormDetail
            {
                Id = form.Id,
                FormTypeId = form.FormTypeId,
                FormTypeName = formType.TypeName,
                LayoutKey = formType.LayoutKey,
                SemesterId = form.SemesterId,
                SemesterName = semester.SemesterName,
                FormContentId = form.FormContentId,
                FormStatusId = form.FormStatusId,
                FormStatusName = formStatus.FormStatusName,
                StudentId = form.StudentId,
                AdvisorId = form.AdvisorId,
                StudentNumber = form.StudentNumber,
                StudentName = form.StudentName,
                StudentSurname = form.StudentSurname,
                StudentPhone = form.StudentPhone,
                StudentEmail = form.StudentEmail,
                StudentFaculty = form.StudentFaculty,
                StudentGpa = form.StudentGpa,
                StudentDepartment = form.StudentDepartment,
                NumOfSemesters = form.NumOfSemesters,
                FormDate = form.FormDate,
                ScholarshipStatus = form.ScholarshipStatus,
                StudentAddress = form.StudentAddress,
                StudentSignature = form.StudentSignature
            };
    }
}