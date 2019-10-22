using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebScraper.Core.Filters;

namespace WebScraper.Core
{
    public class CvOnlineScraper : IScraper
    {
        public List<string> UrlData { get; set; } = new List<String>();

        public void ScrapePageUrls()
        {
            var baseUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";
            var webClient = new HttpClient();
            int pageCounter = 0;
            var continueParsing = true;

            while (continueParsing && pageCounter < 3)
            {
                //Have some delay in parsing
                Thread.Sleep(500);

                var validUrl = baseUrl + pageCounter;
                pageCounter += 1;

                var html = webClient.GetStringAsync(validUrl).Result;


                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);

                var resultNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'offer_primary_info')]//a");

                if (resultNodes.Count == 0)
                {
                    continueParsing = false;
                    continue;
                }

                foreach (var resultNode in resultNodes)
                {
                    UrlData.Add(resultNode.GetAttributeValue("href", string.Empty));
                }

            }

        }

        public void ScrapeJobPortalInfo(string url)
        {
            var webClient = new HttpClient();
            var elementId = "page-main-content";

            var html = webClient.GetStringAsync(url).Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var resultNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@id, 'page-main-content')]");

            var test = "test";
        }

        public void ApplyUrlFilter(IUrlFilter filter)
        {
            var urlsToRemove = filter.UrlsToRemove;

            var filtered = UrlData.Where(u => !urlsToRemove.Any(r => u.Contains(r)));
            filtered = filtered.Where(u => u != "").Select(u => u.Replace("//",""));

            UrlData = filtered.ToList();

        }
    }
}
