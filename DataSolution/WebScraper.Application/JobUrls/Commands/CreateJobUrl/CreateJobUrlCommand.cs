using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScraper.Core.Entities;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.JobUrls.Commands.CreateJobUrl
{
    public class CreateJobUrlCommand : IRequest
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public class Handler : IRequestHandler<CreateJobUrlCommand>
        {
            private readonly IJobDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IJobDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateJobUrlCommand request, CancellationToken cancellationToken)
            {
                var entity = new JobUrl()
                {
                    Id = request.Id,
                    Url = request.Url
                };

                _context.JobUrls.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
