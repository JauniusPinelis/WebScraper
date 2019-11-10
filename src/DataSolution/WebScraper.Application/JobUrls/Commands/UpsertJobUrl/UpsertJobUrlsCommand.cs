using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScraper.Core.Entities;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.JobUrls.Commands.UpsertJobUrl
{
    public class UpsertJobUrlsCommand : IRequest
    {
        public IDictionary<int, string> Urls { get; set; }

        public class Handler : IRequestHandler<UpsertJobUrlsCommand>
        {
            private readonly IDataContext _context;
            private readonly IMediator _mediator;

            public Handler(IDataContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(UpsertJobUrlsCommand request, CancellationToken cancellationToken)
            {
                foreach (var pair in request.Urls)
                {
                    JobUrl entity;

                    var exists = _context.JobUrls.Any(j => j.Url == pair.Value);

                    if (exists)
                    {
                        entity =  _context.JobUrls.SingleOrDefault(j => j.Url == pair.Value);
                    }
                    else
                    {
                        entity = new JobUrl();
                        _context.JobUrls.Add(entity);
                    }

                    entity.Url = pair.Value;

                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
