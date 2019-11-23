using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public abstract class BaseScraper
    {
        public List<JobUrl> jobUrls { get; set; }

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

        public abstract JobUrl ScrapeJobUrlInfo(string html);
    }
}
