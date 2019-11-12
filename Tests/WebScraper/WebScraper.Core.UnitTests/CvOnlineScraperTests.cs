﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineTestPageData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Location.Should().Be("Vilnius");
        }

        [Test]
        public void ScrapeJobUrlInfo_GivenTestData_GetsCorrectUrl()
        {
            string textData = File.ReadAllText(TestContext.CurrentContext.TestDirectory + "\\HtmlTestData\\CvOnlineTestPageData.txt");

            var jobEntity = _scraper.ScrapeJobUrlInfo(textData);

            jobEntity.Url.Should().Be("//www.cvonline.lt/job-ad/forbis-uab/senior-middle-front-end-developers-f4010468.html");
        }

    }
}
