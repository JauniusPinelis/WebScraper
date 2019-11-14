using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebScraper.Core.CvBankas;

namespace WebScraper.Core.UnitTests.CvBankas
{
    [TestFixture]
    public class CvBankasScraperTests
    {
        private readonly CvBankasScraper _scraper;

        public CvBankasScraperTests()
        {
            _scraper = new CvBankasScraper();
        }


        [Test]
        public void ExtractPageUrls_GivenTestData_ReturnCorrectAmountOfJobs()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvBankasTestPageData.txt");

            var jobEntities = _scraper.ExtractPageUrls(textData);

            jobEntities.Count().Should().Be(50);
        }
    }
}
