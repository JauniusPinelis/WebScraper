using System.Collections.Generic;
using WebScraper.Core.Entities;

namespace WebScraper.Core.Shared
{
    public interface IParser
    {
        List<TagCategory> ParseTags(string html, IEnumerable<TagCategory> tagsToSearch);
    }
}