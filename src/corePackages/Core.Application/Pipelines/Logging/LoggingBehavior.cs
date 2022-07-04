using Core.Application.Services;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
                where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        //TODO: We should make an abstraction of ILogger to get rid of the dependency on Serilog here
        private readonly LoggerServiceBase _loggerServiceBase;      
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public LoggingBehavior(LoggerServiceBase loggerServiceBase,
            ICurrentUserService currentUserService,
            IIdentityService identityService)
        {
            _loggerServiceBase = loggerServiceBase;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var logParameters = new List<LogParameter>();

            logParameters.Add(new LogParameter
            {
                Type = request.GetType().Name,
                Value = request
            });

            var userId = _currentUserService.UserId ?? string.Empty;

            var logDetail = new LogDetail
            {
                MethodName = next.Method.Name,
                Parameters = logParameters,
                UserName = await _identityService.GetUserNameAsync(userId) ?? "?",
                UserId = userId                
            };

            _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));

            return next().Result;
        }
    }
}