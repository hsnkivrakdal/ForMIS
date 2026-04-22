using ForMIS.Application.DTOs;
using ForMIS.Application.Interfaces;
using ForMIS.Domain.Entities;
using ForMIS.Domain.Interfaces;

namespace ForMIS.Application.Services;

public class UserService : IDatabaseServiceImplementation<UserDto, User>
{
    public UserService(IDatabaseRepository<User> repository) : base(repository)
    {
    }
}