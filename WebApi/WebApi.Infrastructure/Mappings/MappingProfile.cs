using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Infrastructure.Dtos;
using WebApi.Infrastructure.Entities;

namespace WebApi.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JobHtmlDto, JobHtml>().ReverseMap();
        }
    }
}
