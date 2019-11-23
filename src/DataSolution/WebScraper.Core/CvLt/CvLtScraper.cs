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

namespace WebScraper.Core.CvLt
{
    public class CvLtScraper : BaseScraper, IScraper
    {
        public IEnumerable<JobUrl> ExtractPageUrls(string pageHtml)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageHtml);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//p[contains(@itemtype, 'http://schema.org/JobPosting')]");

            if (resultNodes.Count == 0)
            {
                return jobUrls;
            }

            foreach (var resultNode in resultNodes)
            {
                jobUrls.Add(ScrapeJobUrlInfo(resultNode.OuterHtml));
            }

            return jobUrls;
        }

        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urls)
        {
            throw new NotImplementedException();
        }

        public JobUrl ScrapeJobUrlInfo(string html)
        {
            var resultHtml = new HtmlDocument();
            resultHtml.LoadHtml(html);

            var url = resultHtml.DocumentNode.SelectSingleNode("//meta[contains(@itemprop, 'url')]");
            var title = resultHtml.DocumentNode.SelectSingleNode("//a[contains(@itemprop, 'title')]");
            var salary = resultHtml.DocumentNode.SelectSingleNode("//span[contains(@itemprop, 'baseSalary')]");
            var location = resultHtml.DocumentNode.SelectSingleNode("//meta[contains(@itemprop, 'jobLocation')]");
            var company = resultHtml.DocumentNode.SelectSingleNode("//span[contains(@itemprop, 'name')]");

            return new JobUrl()
            {
                Url = url?.GetAttributeValue("content", string.Empty),
                Salary = salary?.InnerText ?? "",
                Title = title?.InnerText,
                Location = location?.GetAttributeValue("content", string.Empty),
                Company = company?.InnerText,
                JobPortalId = 3
            };
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            var baseUrl = "https://www.cv.lt/employee/announcementsAll.do?regular=true&department=1040&page=";
            var webClient = new HttpClient();
            int pageCounter = 0;
            var continueParsing = true;
            var results = new List<JobUrl>();


            while (continueParsing && pageCounter < 20)
            {
                //Have some delay in parsing
                Thread.Sleep(1000);

                var validUrl = baseUrl + pageCounter;
                pageCounter += 1;

                var html = webClient.GetStringAsync(validUrl).Result;
                Log.Information("CvLtScraper is scraping page no {index}", pageCounter);

                var pageResults = ExtractPageUrls(html);

                // no more found - stop parsing
                if (!pageResults.Any())
                {
                    Log.Information("CvLtScraper finished Scraping");
                    continueParsing = false;
                }

                results.AddRange(pageResults);
            }

            return results;
        }
    }
}
