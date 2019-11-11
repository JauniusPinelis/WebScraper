using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Db;

namespace Webscraper.Application.UnitTests
{
    public class ContextFactory
    {
        public static DataContext Create()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new DataContext(options);

            context.Database.EnsureCreated();


            context.SaveChanges();

            return context;
        }
    }
}
