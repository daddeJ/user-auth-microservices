using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Application.Dtos;
using UserService.Domain.Entities;

namespace UserService.Application.Intefaces
{
    public interface IUserAppService : IBaseAppService<UserDto, CreateUserDto, UpdateUserDto>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}