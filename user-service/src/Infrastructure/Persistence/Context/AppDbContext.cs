using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}