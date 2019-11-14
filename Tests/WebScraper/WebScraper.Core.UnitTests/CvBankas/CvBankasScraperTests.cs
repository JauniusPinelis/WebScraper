using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebScraper.Core.UnitTests.CvBankas
{
    [TestFixture]
    public class CvBankasScraperTests
    {
        [Test]
        public void ExtractPageUrls_GivenTestData_ReturnCorrectAmountOfJobs()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvBankasTestPageData.txt");

            var jobEntities = _scraper.ExtractPageUrls(textData);

            jobEntities.Count().Should().Be(54);
        }
    }
}
