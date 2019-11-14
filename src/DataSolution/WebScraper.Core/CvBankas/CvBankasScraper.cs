using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvBankas
{
    public class CvBankasScraper : IScraper
    {

        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urls)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobUrl> ScrapePageUrls()
        {
            throw new NotImplementedException();
        }

        public JobUrl ScrapeJobUrlInfo(string html)
        {

            var resultHtml = new HtmlDocument();
            resultHtml.LoadHtml(html);

            var url = resultHtml.DocumentNode.SelectSingleNode("//a[contains(@href, 'job-ad')]");
            var salary = resultHtml.DocumentNode.SelectSingleNode("//span[contains(@class, 'salary-blue')]");
            var location = resultHtml.DocumentNode.SelectSingleNode("//a[contains(@itemprop, 'address')]");
            var company = resultHtml.DocumentNode.SelectSingleNode("//a[contains(@itemprop, 'name')]");

            return new JobUrl()
            {
                Url = url?.GetAttributeValue("href", string.Empty),
                Salary = salary?.InnerText ?? "",
                Title = url?.InnerText,
                Location = location?.InnerText,
                Company = company?.InnerText
            };
        }

        public IEnumerable<JobUrl> ExtractPageUrls(string html)
        {
            var results = new List<JobUrl>();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//a[contains(@class, 'list_a can_visited list_a_has_logo')]");

            if (resultNodes.Count == 0)
            {
                return results;
            }

            foreach (var resultNode in resultNodes)
            {
                results.Add(ScrapeJobUrlInfo(resultNode.OuterHtml));
            }

            return results;
        }

    }
}
