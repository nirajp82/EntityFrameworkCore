using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.Repository
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepoServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Add DBContextPool will register ApplicationContext type IOC container, with a scoped lifetime by default.
            //This is safe from concurrent access issues in most ASP.NET Core applications because there is only one thread 
            //executing each client request at a given time, and because each request gets a separate dependency injection scope
            //(and therefore a separate DbContext instance).
            services.AddDbContextPool<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlDB"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
