using Core.CrossCuttingConcerns.Logging.SeriLog;
using MediatR;

namespace Core.Application.Pipelines.ExceptionHandling;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly LoggerServiceBase _logger;

    public UnhandledExceptionBehaviour(LoggerServiceBase logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.Error($"CleanArchitecture Request: Unhandled Exception for Request {requestName} {request} \n" +
                    $"Exception: {ex.Message}.\nError StackTrace: {ex.StackTrace}");
            throw;
        }
    }
}
