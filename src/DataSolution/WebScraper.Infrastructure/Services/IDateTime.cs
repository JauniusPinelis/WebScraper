using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Infrastructure.Services
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
