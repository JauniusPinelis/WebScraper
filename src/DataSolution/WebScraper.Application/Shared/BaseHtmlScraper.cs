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

namespace WebScraper.Application
{
    public class BaseHtmlScraper
    {
        private readonly HttpClient _httpClient;
        private readonly IScraper _scraper;

        protected const int _sleepTime = 300;
        protected const int _scrapeLimit = 200;

        public BaseHtmlScraper(HttpClient httpClient, IScraper scraper)
        {
            _httpClient = httpClient;
            _scraper = scraper;
        }

        public List<JobUrl> ExtractPageUrls(string baseUrl)
        {


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

                    html = _httpClient.GetStringAsync(validUrl).Result;
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

                var html = _httpClient.GetStringAsync(url).Result;
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var resultNode = htmlDocument.DocumentNode.SelectSingleNode($"//div[contains(@id, '{contentId}')]");

                if (resultNode != null)
                    return resultNode.InnerHtml;
                return "";
            }

            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
