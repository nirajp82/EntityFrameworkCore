using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace EntityFrameworkCore.API
{
    public static class SwaggerConfiguration
    {
        private const string _docName = "EFCore";

        public static void ConfigureSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc(_docName, new OpenApiInfo
                { 
                    Title = "Student API",
                    Version = "Version 1",
                    Description = "A simple Student API developed using .net core and entity framework",
                    Contact = new OpenApiContact
                    {
                        Name = "NPatel",
                        Url = new Uri("https://github.com/nirajp82/EntityFrameworkCore"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "The MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                });
            });
        }

        public static void ConfigureSwaggerMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseSwagger();
            appBuilder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{_docName}/swagger.json", "Entity Framework Core API");
            });
        }
    }
}
