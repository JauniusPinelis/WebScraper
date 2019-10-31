using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace WebScraper.Application.Common.Mappings
{
    public interface Imap<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
