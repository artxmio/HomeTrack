using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HomeTrack.WebApi.Middleware.ExceptionHandler;

public static class ExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}