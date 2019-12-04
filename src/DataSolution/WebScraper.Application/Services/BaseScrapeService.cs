using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using HtmlAgilityPack;
using Serilog;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Application.Services
{
    public class BaseScrapeService
    {
        protected IHttpClientFactory _httpClientFactory;
        protected IScraper _scraper;

        protected const int _sleepTime = 1000;

        public BaseScrapeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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

                var pageResults = _scraper.ExtractPageUrls(html);

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

        public string ScrapeJobHtml(string url, string contentId)
        {
            try
            {
                var webClient = _httpClientFactory.CreateClient();
                var html = webClient.GetStringAsync(url).Result;
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var resultNode = htmlDocument.DocumentNode.SelectSingleNode($"//div[contains(@id, '{contentId}')]");

                if (resultNode != null)
                    return resultNode.InnerHtml;
                return "";
            }

            catch (Exception)
            {
                return "";
            }
        }
    }
}
