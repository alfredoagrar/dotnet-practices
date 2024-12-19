using CleanArchitecture.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace WebApi.Extensions
{
    /// <summary>
    /// Provides extension methods for configuring error handling in the application.
    /// </summary>
    public static class ErrorHandlerExtensions
    {
        /// <summary>
        /// Configures the application to use a custom error handler middleware.
        /// </summary>
        /// <param name="app">The application builder to configure.</param>
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    // Retrieve the exception feature from the HTTP context
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null) return;

                    // Set CORS header to allow requests from any origin
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                    // Set the content type of the response to JSON
                    context.Response.ContentType = "application/json";

                    // Determine the status code based on the exception type
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        BadRequestException => (int)HttpStatusCode.BadRequest,
                        OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    // Create an error response object with status code and message
                    var errorResponse = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = contextFeature.Error.GetBaseException().Message
                    };

                    // Serialize the error response object to JSON and write it to the response
                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                });
            });
        }
    }
}
