using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Application;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvLt;
using WebScraper.Core.CvOnline;

namespace Webscraper.Application.UnitTests
{
    [TestFixture]
    public class ScrapeClientTests : TestBase
    {
        

        public ScrapeClientTests()
        {
           
        }

        [Test]
        public void ExtractPageUrls_GivenCvOnlineURlsPage_ShouldReturnCorrectAmountOfUrls()
        {
            SetCvOnlineContent();
            var cvOnlineScrapeClient = new ScrapeClient(_httpClientFactory.CreateClient(""), new CvOnlineScraper());

            var results = cvOnlineScrapeClient.ExtractPageUrls("https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=1");

            results.Count.Should().Be(1080);
        }

        [Test]
        public void ExtractPageUrls_GivenCvBankasURlsPage_ShouldReturnCorrectAmountOfUrls()
        {
            SetCvBankasContent();
            var cvBankasScrapeClient = new ScrapeClient(_httpClientFactory.CreateClient(""), new CvBankasScraper());

            var results = cvBankasScrapeClient.ExtractPageUrls("https://www.cvbankas.lt");

            results.Count.Should().Be(1000);
        }

        [Test]
        public void ExtractPageUrls_GivenCvLtURlsPage_ShouldReturnCorrectAmountOfUrls()
        {
            SetCvLtContent();
            var cvLtScrapeClient = new ScrapeClient(_httpClientFactory.CreateClient(""), new CvLtScraper());

            var results = cvLtScrapeClient.ExtractPageUrls("https://www.cvlt.lt/");

            results.Count.Should().Be(800);
        }


    }
}
