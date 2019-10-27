﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScraper.Core.Dtos;

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
                "/new_tp/map.php",
                "/darbo-skelbimai/1d"
            };
        }

        public void Apply(ref List<JobUrlDto> urlDtos)
        {
            urlDtos = urlDtos.ToList();
            var urls = urlDtos.Select(u => u.Url);
            var urlsToRemove = urls.Where(u => UrlsToRemove.Any(r => u.Contains(r)));

            urlDtos.RemoveAll(u => urlsToRemove.Contains(u.Url) || u.Url == "");
        }
    }
}
