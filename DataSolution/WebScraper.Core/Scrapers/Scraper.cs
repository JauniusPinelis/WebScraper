using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace WebScraper.Core
{
    public class Scraper : IScraper
    {
        public void ScrapePageUrls()
        {
            var urlResults = new List<String>(); 
            var baseUrl = "https://www.cvonline.lt/darbo-skelbimai/informacines-technologijos?page=";
            var webClient = new HttpClient();
            int pageCounter = 0;
            var continueParsing = true;

            while (continueParsing && pageCounter < 6)
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
                    urlResults.Add(resultNode.GetAttributeValue("href", string.Empty));
                }
                var test = "test";

            }


        }
    }
}
