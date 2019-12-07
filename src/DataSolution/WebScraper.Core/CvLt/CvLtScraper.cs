﻿using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvLt
{
    public class CvLtScraper : BaseScraper, IScraper
    {
        public override IEnumerable<JobUrl> ExtractPageUrls(string pageHtml)
        {
            return ExtractPageUrls(pageHtml, "//p[contains(@itemtype, 'http://schema.org/JobPosting')]");
        }

        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urls)
        {
            throw new NotImplementedException();
        }

        public string ScrapeJobPortalInfo(string html)
        {
            throw new NotImplementedException();
        }

        public override JobUrl ScrapeJobUrlInfo(string html)
        {
            var scrapeInfo = new JobUrlScraperInfoModel()
            {
                Url = "//meta[contains(@itemprop, 'url')]",
                UrlAttribute = "content",
                Title = "//a[contains(@itemprop, 'title')]",
                Salary = "//span[contains(@itemprop, 'baseSalary')]",
                Location = "//meta[contains(@itemprop, 'jobLocation')]",
                LocationAttribute = "jobLocation",
                Company = "//span[contains(@itemprop, 'name')]"
            };
            return ScrapeJobUrlInfo(html, scrapeInfo, 3);
        }
    }
}
