using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contexto
{
    public partial class Context : DbContext
    {

        private readonly IConfiguration _configuration;

        public Context()
        {

        }

        public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=lala123");
        }

        public DbSet<TbUser> TbUser { get; set; }

    }
}
