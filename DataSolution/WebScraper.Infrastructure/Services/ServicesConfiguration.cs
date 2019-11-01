using Microsoft.Extensions.DependencyInjection;
using WebScraper.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebScraper.Core.Factories;
using System.Reflection;



namespace WebScraper.Infrastructure.Services
{
    public static class ServicesConfiguration
    {

        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
           
            services.AddDbContext<JobDbContext>(o =>
                o.UseSqlServer(connectionString));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IScraperFactory, ScraperFactory>();
        }
    }
}
