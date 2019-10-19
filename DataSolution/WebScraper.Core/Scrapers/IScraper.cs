using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Filters;

namespace WebScraper.Core
{
    public interface IScraper
    {
        void ScrapePageUrls();
        void ApplyUrlFilter(IUrlFilter filter);
    }
}
