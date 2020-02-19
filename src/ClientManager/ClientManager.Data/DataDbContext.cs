using ClientManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientManager.Data
{
    public class DataDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public DataDbContext(DbContextOptions<DataDbContext> options,
            IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }
    }
}
