using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScraper.Core.Entities;
using WebScraper.Infrastructure.Services;

namespace WebScraper.Infrastructure.Db
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly string _connString = "Server=LAPTOP-9RMR1NCR\\SQLEXPRESS;Database=ScrapeDb;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public DbSet<JobUrl> JobUrls { get; set; }
        public DbSet<JobInfo> JobInfos { get; set; }

        private readonly IDateTime _dateTime;
       

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options, IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
