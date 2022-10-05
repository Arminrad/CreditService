using Microsoft.AspNetCore.Mvc;

namespace CreditApi.ServicesExtensions
{
    public static class ApiVersioningService
    {

        public static void AddCustomApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);

                options.ReportApiVersions = true;
            });
        }
    }
}
