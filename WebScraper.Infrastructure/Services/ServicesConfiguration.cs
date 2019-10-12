using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace WebScraper.Infrastructure.Services
{
    public static class ServicesConfiguration
    {

        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
           
            services.AddDbContext<ScraperDbContext>(o =>
                o.UseSqlServer(connectionString));
        }
    }
}
