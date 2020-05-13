using System.Collections.Generic;
using Core.Entities;

namespace Core.Shared
{
    public interface IParser
    {
        List<TagCategory> ParseTags(string html, IEnumerable<TagCategory> tagsToSearch);
    }
}