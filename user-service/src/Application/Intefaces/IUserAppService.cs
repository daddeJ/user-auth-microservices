using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Domain.Entities;

namespace Application.Intefaces
{
    public interface IUserAppService : IBaseAppService<UserDto, CreateUserDto, UpdateUserDto>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}