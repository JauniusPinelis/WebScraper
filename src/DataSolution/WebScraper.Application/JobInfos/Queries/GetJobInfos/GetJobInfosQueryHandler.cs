using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.JobInfos.Queries.GetJobInfos
{
    public class GetJobInfosQueryHandler : IRequestHandler<GetJobInfosQuery, JobInfosVm>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetJobInfosQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobInfosVm> Handle(GetJobInfosQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.JobInfos
                .ProjectTo<JobInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var vm = new JobInfosVm()
            {
                JobInfos = entities
            };

            return vm;
        }
    }
}
