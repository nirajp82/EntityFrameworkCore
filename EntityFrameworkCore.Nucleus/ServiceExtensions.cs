using EntityFrameworkCore.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Nucleus
{
    public static class ServiceExtensions
    {
        public static void ConfigureNucleusServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton<IMapperHelper, MapperHelper>();
            services.AddSingleton<IStudentEngine, StudentEngine>();
            services.ConfigureRepoServices(configuration);
        }
    }
}
