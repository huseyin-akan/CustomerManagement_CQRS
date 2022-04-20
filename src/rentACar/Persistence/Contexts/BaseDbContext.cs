using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : IdentityDbContext<ApplicationUser>
    {
        protected IConfiguration Configuration { get; set; }
        public BaseDbContext(DbContextOptions options,
            IConfiguration configuration)
            :base(options)
        {
            Configuration = configuration;
        }
        
        public DbSet<CourtCase> CourtCases { get; set ; }
        public DbSet<Court> Courts { get; set ; }
        public DbSet<Todo> Todos { get; set ; }
        public DbSet<Expense> Expenses { get; set ; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")) );
            //}            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly() );
            base.OnModelCreating(modelBuilder);

            //tüm tablolarda delete yapılınca cascade yapılmamasını sağlar:
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.NoAction;
            //}

        }
    }
}
