using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.CvLt;

namespace WebScraper.Core.UnitTests.CvBankas
{
    [TestFixture]
    public class CvLtSCraperTests
    {
        private readonly CvLtScraper _scraper;
        public CvLtSCraperTests()
        {
            _scraper = new CvLtScraper();
        }
    }
}
