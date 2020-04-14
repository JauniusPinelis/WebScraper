using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Application;
using WebScraper.Core.CvBankas;
using WebScraper.Core.CvLt;
using WebScraper.Core.CvOnline;
using WebScraper.Core.Enums;

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
            var cvOnlineScrapeClient = new ScrapeClient(_httpClientFactory.CreateClient(JobPortals.CvOnline.ToString()), new CvOnlineScraper());

            var results = cvOnlineScrapeClient.ExtractPageUrls();

            results.Count.Should().Be(1080);
        }

        [Test]
        public void ExtractPageUrls_GivenCvBankasURlsPage_ShouldReturnCorrectAmountOfUrls()
        {
            SetCvBankasContent();
            var cvBankasScrapeClient = new ScrapeClient(_httpClientFactory.CreateClient(JobPortals.CvBankas.ToString()), new CvBankasScraper());

            var results = cvBankasScrapeClient.ExtractPageUrls();

            results.Count.Should().Be(1000);
        }

        [Test]
        public void ExtractPageUrls_GivenCvLtURlsPage_ShouldReturnCorrectAmountOfUrls()
        {
            SetCvLtContent();
            var cvLtScrapeClient = new ScrapeClient(_httpClientFactory.CreateClient(JobPortals.CvLt.ToString()), new CvLtScraper());

            var results = cvLtScrapeClient.ExtractPageUrls();

            results.Count.Should().Be(800);
        }


    }
}
