using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebScraper.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebScraper.Infrastructure.Mappings;
using WebScraper.Core.Factories;

namespace WebScraper.Infrastructure.Services
{
    public static class ServicesConfiguration
    {

        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
           
            services.AddDbContext<JobDbContext>(o =>
                o.UseSqlServer(connectionString));
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IScraperFactory, ScraperFactory>();
            services.AddScoped<IScrapeService, ScrapeService>();
        }
    }
}
