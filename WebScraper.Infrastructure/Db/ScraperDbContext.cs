using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Infrastructure.Entities;

namespace WebScraper.Infrastructure.Db
{
    public class ScraperDbContext : DbContext
    {
        public DbSet<JobPortalPage> PortalPages { get; set; }
        public DbSet<PortalCategory> PortalCategories { get; set; }

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
