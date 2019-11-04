using Microsoft.Extensions.DependencyInjection;
using WebScraper.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebScraper.Core;
using WebScraper.Core.Filters;
using System;
using WebScraper.Infrastructure;
using WebScraper.Application;
using MediatR;
using WebScraper.Application.Services;

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

            var scrapeService = _serviceProvider.GetService<IScrapingService>();
            var app = new Application(scrapeService);
            app.Run();
           
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var collection = new ServiceCollection();
            collection.ConfigureMapper();
            collection.AddApplication(configuration);
            collection.AddPersistence(configuration, configuration["DefaultConnection"]);

            _serviceProvider = collection.BuildServiceProvider();
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
