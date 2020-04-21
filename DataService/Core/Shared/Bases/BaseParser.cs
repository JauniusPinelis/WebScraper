using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.Configuration.Conventions;
using HtmlAgilityPack;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public class BaseParser : IParser
    {
        public JobInfo ParseInfo(string html)
        {
            throw new NotImplementedException();
        }

        public List<TagCategory> ParseTags(string html, IEnumerable<TagCategory> tagsToSearch)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            return (from tagToSearch in tagsToSearch where html.Contains(tagToSearch.Name) select new TagCategory() { Name = tagToSearch.Name.ToLower() }).ToList();
        }
    }
}
