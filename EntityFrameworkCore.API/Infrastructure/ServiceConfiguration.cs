using EntityFrameworkCore.Nucleus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.API
{
    public static class ServiceConfiguration
    {
        public static void ConfigureAppServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.ConfigureNucleusServices(configuration);
            services.ConfigureSwaggerService();
        }
    }
}
