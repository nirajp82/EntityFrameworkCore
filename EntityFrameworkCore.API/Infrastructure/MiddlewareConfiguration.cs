using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.API
{
    public static class MiddlewareConfiguration
    {
        public static void ConfigureCommonMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.ConfigureSwaggerMiddleware();
        }
    }
}
