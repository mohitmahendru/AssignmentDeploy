using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAssignment
{
    public class ApplicationContext : DbContext
    {
        private static IConfiguration _configuration;
        private string connectionString;
        public ApplicationContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            connectionString = _configuration.GetValue<string>("ConnectionStrings:BlogDB");
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (this.connectionString == null) return;
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    this.connectionString,
                    options => options.EnableRetryOnFailure(4, new TimeSpan(0, 0, 7), null));
            }

        }

    }
}
