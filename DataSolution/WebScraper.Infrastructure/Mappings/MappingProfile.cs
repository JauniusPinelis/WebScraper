using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Dtos;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobUrl, JobPortalPage>();
        }
    }
}
