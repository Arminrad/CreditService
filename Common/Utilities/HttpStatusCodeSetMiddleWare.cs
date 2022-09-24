using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Common.Utilities
{
    public static class HttpStatusCodeSetMiddleWare
    {
        public static void ConfigureBuildInHttpStatusCode(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //
            // app.Run(
            //     (context) =>
            //     {
            //        var respone = context.Response.Body;
            //        
            //
            //     }
            //     );
        }
    }
}
