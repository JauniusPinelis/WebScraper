using Console;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Respawn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    public class Testing
    {
        private static IConfigurationRoot _configuration;

        private static Checkpoint _checkpoint;

        private static IServiceScopeFactory _scopeFactory;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables("Development:");

            _configuration = builder.Build();

            var services = new ServiceCollection();

            //Start setup services

            var app = new App(services, _configuration);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            // end

            EnsureDatabase();
        }

        private static void EnsureDatabase()
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<DataContext>();

            context.Database.Migrate();
        }

        public static DataContext GetDbContext()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<DataContext>();

            return context;
        }


        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
