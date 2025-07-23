using FluentValidation;
using System.Net;
using Newtonsoft.Json;
using HomeTrack.Application.Exceptions;

namespace HomeTrack.WebApi.Middleware.ExceptionHandler;

public class CustomExceptionHandlerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (ex)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.Errors);
                break;
            case NotFoundException:
                code = HttpStatusCode.NotFound;
                break;
            case AlreadyExistException:
                code = HttpStatusCode.NoContent;
                break;
            default: break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        if (result == string.Empty)
        {
            result = JsonConvert.SerializeObject(new {error = ex.Message});
        }

        return context.Response.WriteAsync(result);
    }
}
