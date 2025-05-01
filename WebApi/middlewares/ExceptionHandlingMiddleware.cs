using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var response = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.StackTrace,
                Title = exception.Message
            };

            var serializedResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(serializedResponse);
        }
    }
}