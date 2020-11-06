using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Streamer.Domain.Handlers;
using Streamer.Domain.Repositories;
using Streamer.Infra.Contexts;
using Streamer.Infra.Repositories;
using System.Reflection;

namespace Streamer.Api.Configurations
{
    public static class ApiConfig
    {

        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(CourseHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ProjectHandler).GetTypeInfo().Assembly);

            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("StreamerConnection")));

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<CourseHandler>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<CourseHandler>();
        }


        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
        }

    }

}
