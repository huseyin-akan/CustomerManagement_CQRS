using Application.Features.CourtCases.Rules;
using Application.Features.Todos.Rules;
using Application.Features.Users.Rules;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.ExceptionHandling;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using Core.Security.Jwt;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly() );
            services.AddMediatR(Assembly.GetExecutingAssembly() );
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly() );

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<CourtCaseBusinessRules>();
            services.AddScoped<TodoBusinessRules>();


            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<ICacheService, CacheService>();


            services.AddSingleton<IMailService, MailKitMailService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));            
           

            return services;
        }
    }
}
