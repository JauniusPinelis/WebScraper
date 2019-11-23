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

        public abstract JobUrl ScrapeJobUrlInfo(string html);

        public abstract IEnumerable<JobUrl> ExtractPageUrls(string pageHtml);
    }
}
