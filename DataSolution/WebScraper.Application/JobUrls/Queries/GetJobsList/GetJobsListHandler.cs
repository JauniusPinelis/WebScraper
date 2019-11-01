using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.JobUrls.GetJobsList
{
    public class GetJobsListHandler : IRequestHandler<GetJobsListQuery, JobsListVm>
    {

        private readonly IJobDbContext _context;
        private readonly IMapper _mapper;

        public GetJobsListHandler(IJobDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobsListVm> Handle(GetJobsListQuery request, CancellationToken cancellationToken)
        {
            var jobUrls = await _context.JobUrls
                .ProjectTo<JobUrlLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new JobsListVm
            {
                JobUrls = jobUrls
            };

            return vm;
        }
    }
}
