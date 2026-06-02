using ForMIS.Domain.Entities;

namespace ForMIS.Domain.Interfaces;

public interface IFormRepository : IDatabaseRepository<Form>
{
    Task<List<FormDetail>> GetFormDetailsByStudentNumber(string studentNumber);
    Task<FormDetail?> GetFormDetailsById(int id);
}