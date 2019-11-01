using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace WebScraper.Application.Common.Mappings
{
    public interface ImapFrom<T>
    {
       void Mapping(Profile profile);
    }
}
