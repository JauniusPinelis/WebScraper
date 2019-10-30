using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScraper.Core.Dtos;

namespace WebScraper.Infrastructure.Db
{
    public interface IJobDbContext
    {
        DbSet<JobUrl> JobUrls { get; set; }
        DbSet<JobInfo> JobInfos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
