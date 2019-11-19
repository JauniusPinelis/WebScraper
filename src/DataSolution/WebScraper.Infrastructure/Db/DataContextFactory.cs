using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Infrastructure.Db
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=PC727;Database=ScrapeDb;Trusted_Connection=True;MultipleActiveResultSets=True;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
