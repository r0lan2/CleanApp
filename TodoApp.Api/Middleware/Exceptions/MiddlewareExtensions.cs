using System;
using Microsoft.AspNetCore.Builder;


namespace TodoApp.Api.Middleware.Exceptions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder)
        {
            var options = new ApiExceptionOptions();
            return builder.UseMiddleware<ExceptionHandlerMiddleware>(options);
        }

        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder builder,
            Action<ApiExceptionOptions> configureOptions)
        {
            var options = new ApiExceptionOptions();

            configureOptions(options);

            return builder.UseMiddleware<ExceptionHandlerMiddleware>(options);
        }

    }
}
