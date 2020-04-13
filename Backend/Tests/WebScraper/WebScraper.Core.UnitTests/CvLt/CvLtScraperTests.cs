using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvltSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Location.Should().Be("Vilnius");
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenSalary_GivesCorrectSalary()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvltSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.SalaryText.Should().Be("Nuo 1.289 €");
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsCorrectUrl()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvLtSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Url.Should().Be("https://www.cv.lt/gamybos-pramones-darbai/gis-inzinierius-e-vilniuje-1-344240728");
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsJobPortalId()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.JobPortalId.Should().Be(3);
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsCorrectCompany()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvLtSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Company.Should().Be("\"Vilniaus vandenys\"");
        }

        [Test]
        public void ExtractPageUrls_GivenTestData_ReturnCorrectAmountOfJobs()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvLtTestPageData.txt");

            var jobEntities = _scraper.ExtractPageUrls(textData);

            jobEntities.Count().Should().Be(40);
        }

    }


}
