using Microsoft.Extensions.DependencyInjection;
using WebScraper.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using WebScraper.Infrastructure.Services;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebScraper.Core;

namespace WebScraper.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var collection = new ServiceCollection();
            collection.ConfigureDbContext(configuration["DefaultConnection"]);

            var serviceProvider = collection.BuildServiceProvider();

            serviceProvider.Dispose();

            // will need to refactor code

            var scraper = new Scraper();
            scraper.ParseJobPortalLinks();
               
        }

       
    }
}
