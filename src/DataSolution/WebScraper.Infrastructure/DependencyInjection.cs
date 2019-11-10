using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Factories;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration,
             string connectionString)
        {
            services.AddDbContext<JobDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddSingleton<IJobDbContext>(provider => provider.GetService<JobDbContext>());

            return services;
        }
    }
}
