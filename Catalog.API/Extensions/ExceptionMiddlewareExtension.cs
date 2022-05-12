using Catalog.Application.DTOs.Base;
using Catalog.Infrastructure.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Catalog.API.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        ErrorResponseDTO errorDTO = new()
                        {
                            StatusCode = HttpStatusCode.InternalServerError,
                            Message = $"Internal server error when processing this request. Cause: {contextFeature.Error.Message}"
                        };

                        await context.Response.WriteAsync(JsonHelper.ToJson<ErrorResponseDTO>(errorDTO));                    }
                });
            });
        }
    }
}
