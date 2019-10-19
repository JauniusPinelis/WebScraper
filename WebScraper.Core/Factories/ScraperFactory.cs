using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Factories
{
    public static class ScraperFactory
    {
        public static IScraper Build(string website)
        {
            switch (website)
            {
                case "cvonline":
                    return new Scraper();
            }
        }
    }
}
