using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Db;
using WebScraper.Infrastructure.Repositories;

namespace Webscraper.Application.UnitTests
{
    public class ContextTestBase : IDisposable
    {
        protected readonly DataContext _context;
        protected readonly IUnitOfWork _unitOfWork;

        public ContextTestBase()
        {
            _context = ContextFactory.CreateTestDataContext();
            _unitOfWork = ContextFactory.CreateTestUnitOfWork();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(_context);
        }
    }
}
