using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public interface IUrlFilter
    {
        void Apply(ref List<JobUrl> urls);
    }
}
