using HtmlAgilityPack;
using System;
using WebScraper.Core.Entities;
using WebScraper.Core.Shared;

namespace WebScraper.Core.CvOnline
{
    public class CvOnlineParser : BaseParser
    {

        private string ParseTitle(string html)
        {

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'application-title')]//h1");
            var title = resultNodes[0].InnerText;
            return title;
        }

        private string ParseSalary(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var resultNodes = htmlDocument.DocumentNode.SelectNodes("//li[contains(text(), 'EUR')]");
            var title = resultNodes[0].InnerText;

            //a[contains(text(), 'About us') or contains(text(), 'about us')]
            return String.Empty;
        }

        public JobInfo ParseInfo(string html)
        {
            return new JobInfo()
            {
                Title = ParseTitle(html),
                SalaryText = ParseSalary(html)
            };

        }
    }
}
