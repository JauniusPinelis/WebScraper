using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Filters
{
    public class CvOnlineUrlFilter : IUrlFilter
    {
        public List<string> UrlsToRemove { get; set; }

        public CvOnlineUrlFilter()
        {
            UrlsToRemove = new List<string>
            {
                "test",
                "/new_tp/map.php"
            };
        }
    }
}
