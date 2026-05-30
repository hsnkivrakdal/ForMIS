using ForMIS.Domain.Entities;

namespace ForMIS.Domain.Interfaces;

public interface IStudentRepository : IDatabaseRepository<Student>
{
    Task<StudentDetail?> GetStudentDetailsByIdentityNumber(string identityNumber);
}