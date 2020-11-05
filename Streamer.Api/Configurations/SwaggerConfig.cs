using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Streamer.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Streamer",
                        Version = "v1"
                    });
            });
        }

    }
}

