using Application.Services;
using Application.Services.Repositories;
using Core.Application.Transaction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Contexts;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("BlackRamConnectionString") ));
            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddScoped<ICourtCaseRepository, CourtCaseRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
