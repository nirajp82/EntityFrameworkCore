using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.Repository
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepoServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlDB"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
