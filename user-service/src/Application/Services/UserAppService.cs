using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Intefaces;
using Application.Intefaces.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class UserAppService : BaseAppService<User, UserDto, CreateUserDto, UpdateUserDto>, IUserAppService
    {
        protected readonly IUserRepository _userRepository;
        public UserAppService(IBaseRepository<User> repository, IMapper mapper, IUserRepository userRepository) : base(repository, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var entity = await _userRepository.GetByEmailAsync(email);
            return entity;
        }
    }
}