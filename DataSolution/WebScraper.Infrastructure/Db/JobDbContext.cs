using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Db
{
    public class JobDbContext : DbContext, IJobDbContext
    {
        private readonly string _connString = "Server=LAPTOP-9RMR1NCR\\SQLEXPRESS;Database=ScrapeDb;Trusted_Connection=True";

        public DbSet<JobUrl> JobUrls { get; set; }
        public DbSet<JobInfo> JobInfos { get; set; }
       

        public JobDbContext() : base()
        {

        }

        public JobDbContext(DbContextOptions<JobDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobDbContext).Assembly);
        }
    }
}
