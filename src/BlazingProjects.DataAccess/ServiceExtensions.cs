using BlazingProjects.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<AppDbContext>(config => config.UseSqlServer(connectionString));
        }

    }
}
