using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvOnline
{
    public class CvOnlineScraper : BaseScraper,IScraper
    {
        private const int _jobPortalId = 1;
      


        public override IEnumerable<JobUrl> ExtractPageUrls(string pageHtml)
        {
            return ExtractPageUrls(pageHtml, "//div[contains(@class, 'offer_primary_info')]");
        }

       

        public override JobUrl ScrapeJobUrlInfo(string html)
        {
            var scrapeInfo = new JobUrlScraperInfoModel()
            {
                Url = "//a[contains(@href, 'job-ad')]",
                UrlAttribute = "href",
                Title = "//a[contains(@href, 'job-ad')]",
                TitleAttribute = "title",
                Salary = "//span[contains(@class, 'salary-blue')]",
                Location = "//a[contains(@itemprop, 'address')]",
                Company = "//a[contains(@itemprop, 'name')]"
            };
            return ScrapeJobUrlInfo(html, scrapeInfo, 1);
        }
        private string TrimStart(string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString) || string.IsNullOrEmpty(target)) return target;

            string result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }

    

        public string ScrapeJobPortalInfo(string html)
        {
            return base.ScrapeJobHtml( html , "page-main-content");
        }
    }
}
