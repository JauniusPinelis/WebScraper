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

namespace WebScraper.Application.JobUrls.GetJobsUrls
{
    public class GetJobsHandler : IRequestHandler<GetJobUrlsQuery, JobsVm>
    {

        private readonly IJobDbContext _context;
        private readonly IMapper _mapper;

        public GetJobsHandler(IJobDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobsVm> Handle(GetJobUrlsQuery request, CancellationToken cancellationToken)
        {
            var jobUrls = await _context.JobUrls
                .ProjectTo<JobUrlLsookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new JobsVm
            {
                JobUrls = jobUrls
            };

            return vm;
        }
    }
}
