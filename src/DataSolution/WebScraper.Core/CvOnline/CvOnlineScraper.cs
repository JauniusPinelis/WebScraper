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
        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urlDtos)
        {
            var urls = urlDtos.ToList();
            var results = new List<JobInfo>();
            var webClient = new HttpClient();


            var limit = 50;
            var delay = 1000;

            for (int i = 0; i <= limit; i++)
            {
                Thread.Sleep(delay);
                var html = ScrapeJobPortalInfo(urls[i].Url, webClient);

                results.Add(new JobInfo()
                {
                    JobUrlId = urls[i].Id,
                    HtmlCode = html
                });
            }

            return results;
        }



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

        public void ScrapeJobPortalInfo(string html)
        {

        }

        private string ScrapeJobPortalInfo(string html)
        {

            //temp stuff but this needs to be better refactored
            url = TrimStart(url, "//");
            url = "http://" + url;

           return base.ScrapeJobHtml( html , "page-main-content");
            
        }
    }
}
