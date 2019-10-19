using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Filters
{
    public interface IUrlFilter
    {
        List<string> UrlsToRemove { get; set; }
    }
}
