using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Intefaces.Common
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}