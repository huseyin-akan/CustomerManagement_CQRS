using Application.Features.CourtCases.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
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


            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<ICacheService, CacheService>();


            services.AddSingleton<IMailService, MailKitMailService>();
            services.AddSingleton<LoggerServiceBase, FileLogger>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));            

            return services;
        }
    }
}
