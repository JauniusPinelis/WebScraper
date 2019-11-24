using HtmlAgilityPack;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public abstract class BaseScraper
    {
        public List<JobUrl> jobUrls { get; set; }

        private const int _sleepTime = 1000;

        public BaseScraper()
        {
            jobUrls = new List<JobUrl>();
        }

        public IEnumerable<JobUrl> ExtractPageUrls(string pageHtml, string selectQuery)
        {

            if (pageHtml == "")
                return jobUrls;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageHtml);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes(selectQuery);

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

        public IEnumerable<JobUrl> ScrapePageUrls(string baseUrl)
        {
            
            var webClient = new HttpClient();
            int pageCounter = 0;
            var continueParsing = true;
            var results = new List<JobUrl>();


            while (continueParsing && pageCounter < 20)
            {
                string html;
                try
                {
                    //Have some delay in parsing
                    Thread.Sleep(_sleepTime);

                    var validUrl = baseUrl + pageCounter;
                    pageCounter += 1;
                    Log.Information("Scraping page {pageIndex}", pageCounter);

                    html = webClient.GetStringAsync(validUrl).Result;
                }
                catch (Exception)
                {
                    // html is empty
                    html = "";
                }

                var pageResults = ExtractPageUrls(html);

                // no more found - stop parsing
                if (!pageResults.Any())
                {
                    Log.Information("Finished scraping page urls");
                    continueParsing = false;
                }

                results.AddRange(pageResults);
            }

            return results;
        }

        public JobUrl ScrapeJobUrlInfo()
        {
            var scrapeInfo = new JobUrlScraperInfoModel()
            return ScrapeJobUrlInfo();
        }

        public override JobUrl ScrapeJobUrlInfo(JobUrlScraperInfoModel scrapeInfo)
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

        public abstract JobUrl ScrapeJobUrlInfo(string html);

        public abstract IEnumerable<JobUrl> ExtractPageUrls(string pageHtml);
    }

    public class JobUrlScraperInfoModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }

    }
}
