using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Dtos;

namespace WebScraper.Core.Filters
{
    public interface IUrlFilter
    {
        void Apply(ref List<JobUrlDto> urls);
    }
}
