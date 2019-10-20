using Microsoft.Extensions.DependencyInjection;
using WebScraper.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using WebScraper.Infrastructure.Services;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebScraper.Core;
using WebScraper.Core.Filters;
using System;

namespace WebScraper.Console
{
    // Follow this
    // https://dzone.com/articles/dependency-injection-in-net-core-console-applicati
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();

            var scraper = new CvOnlineScraper();
            scraper.ScrapePageUrls();

            var cvOnlineFilter = new CvOnlineUrlFilter();
            scraper.ApplyUrlFilter(cvOnlineFilter);

            var result = scraper.UrlData;

            DisposeServices();

        }

        private static void RegisterServices()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var collection = new ServiceCollection();
            collection.ConfigureDbContext(configuration["DefaultConnection"]);
            collection.ConfigureMapper();

           var serviceProvider = collection.BuildServiceProvider();
            serviceProvider.Dispose();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
