using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Configuration.Conventions;
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
            throw new NotImplementedException();
        }
    }
}
