using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace WebScraper.Application.Common.Mappings
{
    public class ImapFrom<T>
    {
        public virtual void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
