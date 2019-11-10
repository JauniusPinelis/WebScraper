using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScraper.Core.Entities;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Application.JobInfos.Commands.UpsertJobInfo
{
    public class UpsertJobInfoCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public string HtmlCode { get; set; }
        public int? JobUrlId { get; set; }

        public class Handler : IRequestHandler<UpsertJobInfoCommand, int>
        {
            private readonly IDataContext _context;
            private readonly IMediator _mediator;

            public Handler(IDataContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<int> Handle(UpsertJobInfoCommand request, CancellationToken cancellationToken)
            {
                JobInfo entity;
                var exists = _context.JobInfos.Any(j => j.HtmlCode == request.HtmlCode);

               if (request.Id.HasValue && exists)
                {
                    entity = await _context.JobInfos.FindAsync(request.Id.Value);
                }
               else
                {
                    entity = new JobInfo();
                    _context.JobInfos.Add(entity);
                }

                entity.HtmlCode = request.HtmlCode;
                entity.JobUrlId = request.JobUrlId;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
                
            }
        }
    }
}
