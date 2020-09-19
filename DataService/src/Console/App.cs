using Serilog;
using Application.Services;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Infrastructure;

namespace Console
{
    public class App
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            RegisterServices();
        }

        public App(IServiceCollection services, IConfigurationRoot configuration)
        {
            RegisterServices(services, configuration);
        }

        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            ConfigureSerilog();
            ConfigureServices(services, configuration);
        }

        public void RegisterServices()
        {
            ConfigureSerilog();

            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var services = new ServiceCollection();

            ConfigureServices(services, configuration);
        }

        public void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.ConfigureMapper();
            services.AddApplication(configuration);
            services.AddPersistence(configuration, configuration.GetConnectionString("DefaultConnection"));

            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureSerilog()
        {
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .CreateLogger();

            Log.Information("The global logger has been configured");
        }

        public void Run()
        {
            var scrapeService = _serviceProvider.GetService<IDataService>();
            scrapeService.Run();
        }
    }
}
