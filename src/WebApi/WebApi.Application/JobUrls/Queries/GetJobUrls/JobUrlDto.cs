using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.Mappings;
using WebApi.Core.Entities;

namespace WebApi.Application.JobUrls.Queries.GetJobUrls
{
    public class JobUrlDto : IMapFrom<JobUrl>
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Location { get; set; }

        public string Salary { get; set; }

        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<JobUrl, JobUrlDto>();   
        }
    }


}
