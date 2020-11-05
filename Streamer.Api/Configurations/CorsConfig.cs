using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Streamer.Api.Configurations
{
    public static class CorsConfig
    {

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        }

        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
        {
            return app.UseCors("MyPolicy");
        }

    }
}
