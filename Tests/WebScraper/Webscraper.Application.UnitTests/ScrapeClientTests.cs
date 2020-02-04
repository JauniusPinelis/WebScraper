using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Application;
using WebScraper.Core.CvOnline;

namespace Webscraper.Application.UnitTests
{
    [TestFixture]
    public class ScrapeClientTests : TestBase
    {
        private ScrapeClient _cvOnlineScrapeClient;

        public ScrapeClientTests()
        {
            _cvOnlineScrapeClient = new ScrapeClient(_httpClientFactory.CreateClient(""), new CvOnlineScraper());
        }

        [Test]
        public void ExtractPageUrls_GivenCvonlineURlsPage_ShouldReturnCorrectAmountOfUrls()
        {
            var results = _cvOnlineScrapeClient.ExtractPageUrls("https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=1");

            results.Count.Should().Be(1080);
        }
    }
}
