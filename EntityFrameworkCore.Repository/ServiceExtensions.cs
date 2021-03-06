﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkCore.Repository
{
    public static class ServiceExtensions
    {
        #region Member
        static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        #endregion


        #region Extension Method
        public static void ConfigureRepoServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Add DBContextPool will register ApplicationContext type IOC container, with a scoped lifetime by default.
            //This is safe from concurrent access issues in most ASP.NET Core applications because there is only one thread 
            //executing each client request at a given time, and because each request gets a separate dependency injection scope
            //(and therefore a separate DbContext instance).
            services.AddDbContextPool<ApplicationContext>(optionsBuilder =>
            {
#if DEBUG
                //tie-up DbContext with LoggerFactory object
                optionsBuilder = optionsBuilder.UseLoggerFactory(loggerFactory)
                 .EnableSensitiveDataLogging();  
#endif
                optionsBuilder
                            .UseSqlServer(configuration.GetConnectionString("SqlDB"),
                                options => options.EnableRetryOnFailure());
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IModelHelper, ModelHelper>();
        }
        #endregion
    }
}
