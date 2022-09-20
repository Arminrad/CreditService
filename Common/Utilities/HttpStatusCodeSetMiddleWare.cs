using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Log4netWebapi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Features;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
