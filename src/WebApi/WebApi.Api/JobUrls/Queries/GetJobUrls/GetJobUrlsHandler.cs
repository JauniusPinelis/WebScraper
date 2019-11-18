using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Infrastructure.Db;

namespace WebApi.Api.JobUrls.Queries.GetJobUrls
{
    public class GetJobUrlsHandler : IRequestHandler<GetJobUrlsQuery, JobUrlsVm>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetJobUrlsHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobUrlsVm> Handle(GetJobUrlsQuery request, CancellationToken cancellationToken)
        {
            var jobUrls = await _context.JobUrls
                .ProjectTo<JobUrlDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new JobUrlsVm
            {
                JobUrls = jobUrls,
            };

            return vm;
        }
    }
}
