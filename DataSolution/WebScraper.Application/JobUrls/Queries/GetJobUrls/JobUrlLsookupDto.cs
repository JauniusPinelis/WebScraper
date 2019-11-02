using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Application.Common.Mappings;
using WebScraper.Core.Entities;

namespace WebScraper.Application.JobUrls.GetJobsUrls
{
    public class JobUrlLsookupDto : ImapFrom<JobUrl>
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<JobUrl, JobUrlLsookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Url, opt => opt.MapFrom(s => s.Url));
        }

    }
}
