using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebScraper.Core.CvLt;

namespace WebScraper.Core.UnitTests.CvLt
{
    [TestFixture]
    public class CvLtScraperTests
    {

        private readonly CvLtScraper _scraper;

        public CvLtScraperTests()
        {
            _scraper = new CvLtScraper();
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenLocationVilnius_GivesVilnius()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Location.Should().Be("Vilnius");
        }
    }

    
}
