using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebScraper.Infrastructure.Db
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private IConfiguration Configuration { get; }

        //Needed for migrations
        public DataContextFactory()
        {
            //TODO: ok in need to refactor this to move connection string into environment variable.. This would solve the mess with connection string

        }

        public DataContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DataContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            /* TODO: this can be solved with environment variables or differently, but needs refactoring
             https://www.benday.com/2017/02/17/ef-core-migrations-without-hard-coding-a-connection-string-using-idbcontextfactory/ */

            optionsBuilder.UseSqlServer(Configuration != null ? Configuration["ConnectionStrings:DefaultConnection"] 
                : "Server=LAPTOP-9RMR1NCR\\SQLEXPRESS;Database=ScrapeDb;Trusted_Connection=True;MultipleActiveResultSets=True;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
