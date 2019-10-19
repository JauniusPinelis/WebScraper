using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Infrastructure.Services
{
    public class DbRepository
    {
        private ScraperDbContext _context;
        public DbRepository(ScraperDbContext context)
        {
            _context = context;
        }


    }
}
