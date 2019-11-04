using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Application.Common.Mappings;
using WebScraper.Core.Entities;

namespace WebScraper.Application.JobInfos.Queries.GetJobInfos
{
    public class JobInfoDto : ImapFrom<JobInfo>
    {
        public int Id { get; set; }

        public string HtmlCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JobInfo, JobInfoDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.HtmlCode, opt => opt.MapFrom(s => s.HtmlCode)).ReverseMap();
        }
    }
}
