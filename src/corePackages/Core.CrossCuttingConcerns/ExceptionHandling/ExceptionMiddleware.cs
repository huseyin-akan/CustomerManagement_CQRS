using Core.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.ExceptionHandling
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {                
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            object errors = null;

            if (exception.GetType() == typeof(UnauthorizedAccessException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                return context.Response.WriteAsync(new BusinessProblemDetails
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Type = "https://example.com/probs/unauthorized",
                    Title = "Unauthorized",
                    Detail = exception.Message,
                    Instance = ""
                }.ToString());
            }

            if (exception.GetType() == typeof(ForbiddenAccessException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;

                return context.Response.WriteAsync(new BusinessProblemDetails
                {
                    Status = StatusCodes.Status403Forbidden,
                    Type = "https://example.com/probs/business",
                    Title = "Forbidden access",
                    Detail = exception.Message,
                    Instance = ""
                }.ToString());
            }
            if (exception.GetType() == typeof(ValidationException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errors = ((ValidationException)exception).Errors;

                return context.Response.WriteAsync(new ValidationProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://example.com/probs/validation",
                    Title = "Validation error(s)",
                    Detail = (errors as IEnumerable<ValidationFailure>)?.FirstOrDefault()?.ToString(), //only the first error is enough
                    Instance = "",
                    Errors = errors
                }.ToString());
            }

            if (exception.GetType() == typeof(BusinessException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return context.Response.WriteAsync(new BusinessProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://example.com/probs/business",
                    Title = "Business exception",
                    Detail = exception.Message,
                    Instance = ""
                }.ToString());
            }


            if (exception.GetType() == typeof(NotFoundException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return context.Response.WriteAsync(new BusinessProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://example.com/probs/notfound",
                    Title = "The specified resource was not found.",
                    Detail = exception.Message,
                    Instance = ""
                }.ToString());
            }

            var unknownException = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://example.com/probs/internal",
                Title = "Internal exception",
                Detail = exception.Message,
                Instance = ""
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(unknownException) );
        }
    }
}
