using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebScraper.Core.CvOnline;

namespace WebScraper.Core.UnitTests
{
    [TestFixture]
    public class CvOnlineScraperTests
    {
        private readonly CvOnlineScraper _scraper;

        public CvOnlineScraperTests()
        {
            _scraper = new CvOnlineScraper();
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenLocationVilnius_GivesVilnius()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Location.Should().Be("Vilnius");
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsCorrectUrl()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Url.Should().Be("//www.cvonline.lt/job-ad/forbis-uab/senior-middle-front-end-developers-f4010468.html");
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsJobPortalId()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.JobPortalId.Should().Be(1);
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsCorrectCompany()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineSingleUrlTestData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Company.Should().Be("FORBIS, UAB");
        }

        [Test]
        public void ExtractPageUrls_GivenTestData_ReturnCorrectAmountOfJobs()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineTestPageData.txt");

            var jobEntities = _scraper.ExtractPageUrls(textData);

            jobEntities.Count().Should().Be(54);
        }

    }
}
