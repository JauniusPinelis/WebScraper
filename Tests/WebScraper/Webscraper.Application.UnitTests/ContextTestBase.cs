using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Db;

namespace Webscraper.Application.UnitTests
{
    public class ContextTestBase : IDisposable
    {
        protected readonly DataContext _context;

        public ContextTestBase()
        {
            _context = ContextFactory.Create();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(_context);
        }
    }
}
