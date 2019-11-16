using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvLt
{
    public class CvLtScraper : IScraper
    {
        public IEnumerable<JobUrl> ExtractPageUrls(string pageHtml)
        {
            var results = new List<JobUrl>();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(pageHtml);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//p[contains(@itemtype, 'http://schema.org/JobPosting')]");

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

        public IEnumerable<JobInfo> ScrapeJobHtmls(IEnumerable<JobUrl> urls)
        {
            throw new NotImplementedException();
        }

        public JobUrl ScrapeJobUrlInfo(string html)
        {
            var resultHtml = new HtmlDocument();
            resultHtml.LoadHtml(html);

            var url = resultHtml.DocumentNode.SelectSingleNode("//meta[contains(@itemprop, 'url')]");
            var title = resultHtml.DocumentNode.SelectSingleNode("//meta[contains(@itemprop, 'title')]");
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
            throw new NotImplementedException();
        }
    }
}
