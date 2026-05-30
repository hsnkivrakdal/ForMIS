using ForMIS.Domain.Entities;

namespace ForMIS.Domain.Interfaces;

public interface IFormRepository : IDatabaseRepository<Form>
{
    Task<List<FormDetail>> GetFormDetailsByStudentId(int studentId);
    Task<FormDetail?> GetFormDetailsById(int id);
}