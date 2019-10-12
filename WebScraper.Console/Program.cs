using Microsoft.Extensions.DependencyInjection;
using WebScraper.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using WebScraper.Infrastructure.Services;

namespace WebScraper.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .ConfigureDbContext()
                .BuildServiceProvider();
               
        }
    }
}
