using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Infrastructure.Db
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private IConfiguration Configuration { get; }
        public DataContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DataContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);

            return new DataContext(optionsBuilder.Options);
        }
    }
}
