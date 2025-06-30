using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Application.Intefaces;
using UserService.Application.Intefaces.Common;
using UserService.Application.Services;
using UserService.Infrastructure.Persistence.Context;
using UserService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Dtos;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserServiceDependencies(this IServiceCollection services, string connectionString)
        {
            AddDbContext(services, connectionString);
            AddApplicationServices(services);
            AddRepositories(services);
            return services;
        }
        private static void AddDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }
        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IBaseAppService<UserDto, CreateUserDto, UpdateUserDto>,
                   BaseAppService<User, UserDto, CreateUserDto, UpdateUserDto>>();
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}