using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Configuration.Conventions;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public class BaseParser : IParser
    {
        public JobInfo ParseInfo(JobInfo jobHtml)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ParseTags()
        {
            throw new NotImplementedException();
        }
    }
}
