using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Db
{
    public interface IDataContext
    {
        DbSet<JobUrl> JobUrls { get; set; }
        DbSet<JobInfo> JobInfos { get; set; }
        DbSet<JobPortal> JobPortals { get; set;}
        DbSet<Salary> Salaries { get; set; }

        int SaveChanges();
    }
}
