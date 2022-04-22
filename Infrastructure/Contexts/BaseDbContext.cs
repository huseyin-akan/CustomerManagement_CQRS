using Application.Services;
using Core.Persistence;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    //we specify the types that we use for User, Role and Primary Key
    public class BaseDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        protected IConfiguration Configuration { get; set; }
        private readonly ICurrentUserService _currentUserService;
        private readonly IDomainEventService _domainEventService;
        public BaseDbContext(DbContextOptions options,
            IConfiguration configuration,
            ICurrentUserService currentUserService,
            IDomainEventService domainEventService)
            : base(options)
        {
            Configuration = configuration;
            _currentUserService = currentUserService;
            _domainEventService = domainEventService;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            var events = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .ToArray();

            var result = await base.SaveChangesAsync(cancellationToken);

            await DispatchEvents(events);

            return result;
        }

        private async Task DispatchEvents(DomainEvent[] events)
        {
            foreach (var @event in events)
            {
                @event.IsPublished = true;
                await _domainEventService.Publish(@event);
            }
        }
    }
}
