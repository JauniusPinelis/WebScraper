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

        [Test]
        public void ScrapeJobUrlInfo_GivenLocationVilnius_GivesVilniuje()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvBankasSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Location.Should().Be("Vilniuje");
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsCorrectUrl()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvBankasSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Url.Should().Be("https://www.cvbankas.lt/sap-basis-administratorius-e-vilniuje/1-6411437");
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsCorrectCompany()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvBankasSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Company.Should().Be("Telia");
        }
    }
}
