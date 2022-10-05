using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace WebFramework.Swagger
{
    public class SetVersionInPaths : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var updatedPaths = new OpenApiPaths();
            foreach (var p in swaggerDoc.Paths)
                updatedPaths.Add(p.Key.Replace("v{version}", swaggerDoc.Info.Version),
                    p.Value);
            swaggerDoc.Paths = updatedPaths;


            //
        }
    }
}
