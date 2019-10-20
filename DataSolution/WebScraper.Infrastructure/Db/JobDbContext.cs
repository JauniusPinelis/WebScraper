using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Db
{
    public class JobDbContext : DbContext
    {
        private readonly string _connString = "Server=LAPTOP-9RMR1NCR\\SQLEXPRESS;Database=ScrapeDb;Trusted_Connection=True";

        public DbSet<JobPortalPage> PortalPages { get; set; }
        public DbSet<PortalCategory> PortalCategories { get; set; }

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
            modelBuilder.Entity<PortalCategory>().HasData(new PortalCategory()
            {
                Id = 1,
                Name = "CvOnline.lt"
            });
        }
    }
}
