using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Shared
{
    public interface IScraper
    { 
        JobUrl ScrapeJobUrlInfo(string html);

        IEnumerable<JobUrl> ExtractPageUrls(string html);

    }
}
