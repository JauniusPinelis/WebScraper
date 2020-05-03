using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using WebScraper.Infrastructure;
using WebScraper.Application;
using WebScraper.Application.Services;
using Serilog;

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

            var scrapeService = _serviceProvider.GetService<IDataService>();
            var app = new Application(scrapeService);
            app.Run();
           
            DisposeServices();
        }

        private static void RegisterServices()
        {
            ConfigureSerilog();


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

        private static void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
			  .Enrich.FromLogContext()
			  .WriteTo.Console()
			  .CreateLogger();

            Log.Information("The global logger has been configured");
        }
    }
}
