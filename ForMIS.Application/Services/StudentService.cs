using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class StudentService : IDatabaseServiceImplementation<StudentDto, Student>
{
    public StudentService(IDatabaseRepository<Student> repository) : base(repository)
    {
    }
}