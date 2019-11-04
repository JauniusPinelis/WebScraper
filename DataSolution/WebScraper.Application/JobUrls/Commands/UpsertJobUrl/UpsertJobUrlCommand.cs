using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScraper.Core.Entities;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.JobUrls.Commands.CreateJobUrl
{
    public class UpsertJobUrlCommand : IRequest
    {
        public int? Id { get; set; }
        public string Url { get; set; }

        public class Handler : IRequestHandler<UpsertJobUrlCommand>
        {
            private readonly IJobDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IJobDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpsertJobUrlCommand request, CancellationToken cancellationToken)
            {

                JobUrl entity;
                var exists = _context.JobUrls.Any(j => j.Url == request.Url);

                if (request.Id.HasValue && exists)
                {
                    entity = await _context.JobUrls.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new JobUrl();
                    _context.JobUrls.Add(entity);
                }

                entity.Url = request.Url;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
