using System.Net;
using System.Text.Json;
using Countify.Application.Common.Exceptions;

namespace Countify.Api.Middleware;

public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            succeeded = false,
            message = "An error occurred.",
            errors = new List<string>()
        };

        switch (exception)
        {
            case ValidationException validationException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response = new
                {
                    succeeded = false,
                    message = "Validation failed.",
                    errors = validationException.Errors
                        .SelectMany(e => e.Value)
                        .ToList()
                };
                break;

            case NotFoundException:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                response = new
                {
                    succeeded = false,
                    message = exception.Message,
                    errors = new List<string> { exception.Message }
                };
                break;

            case UnauthorizedException:
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                response = new
                {
                    succeeded = false,
                    message = exception.Message,
                    errors = new List<string> { exception.Message }
                };
                break;

            case ForbiddenAccessException:
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                response = new
                {
                    succeeded = false,
                    message = exception.Message,
                    errors = new List<string> { exception.Message }
                };
                break;

            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response = new
                {
                    succeeded = false,
                    message = "An internal server error occurred.",
                    errors = new List<string> { "An unexpected error occurred. Please try again later." }
                };
                break;
        }

        var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
    }
}