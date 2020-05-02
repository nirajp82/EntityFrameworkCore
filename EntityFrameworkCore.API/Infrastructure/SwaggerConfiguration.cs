using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;


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
                options.SwaggerDoc(_docName, new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Entity Framework Core API Doc." });
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
