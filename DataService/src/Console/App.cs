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

        private IConfigurationRoot _configuration;

        public App()
        {
            RegisterServices();
        }

        public void RegisterServices()
        {
            ConfigureSerilog();

            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            var services = new ServiceCollection();

            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureMapper();
            services.AddApplication(_configuration);
            services.AddPersistence(_configuration, _configuration.GetConnectionString("DefaultConnection"));

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
