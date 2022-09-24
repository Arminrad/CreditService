using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Log4netWebapi.Extensions
{
    public static class ExceptionMiddleWareExceptions
    {
        public static void ConfigureBuildInExceptionHandler(
            this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var _logger = loggerFactory.CreateLogger("ExceptionHandlerMiddleware");
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();
                    if (contextFeature != null)
                    {
                        string _error = $"[{context.Response.StatusCode}] - {contextFeature.Error.Message}: {contextRequest.Path}";
                        _logger.LogError(_error);
                        ApiResult _result = new ApiResult()
                        {
                            IsSuccess = false,
                            Message = _error
                        };
                        await context.Response.WriteAsync(JsonSerializer.Serialize(_result));
                    }
                });
            });
        }


        public class ApiResult
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
        }
    }
}
