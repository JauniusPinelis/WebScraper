using Microsoft.EntityFrameworkCore;
using WebScraper.Core.Entities;
using WebScraper.Infrastructure.Services;

namespace WebScraper.Infrastructure.Db
{
    public class DataContext : DbContext, IDataContext
    {

        public DbSet<JobUrl> JobUrls { get; set; }
        public DbSet<JobInfo> JobInfos { get; set; }
        public DbSet<JobPortal> JobPortals { get; set; }
        public DbSet<Tag> Tags { get; set; }

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
            SeedData(modelBuilder);
        }

        protected void SeedData (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobPortal>().HasData(
                new JobPortal() { Id = 1, Name = "CvOnline" },
                new JobPortal() { Id = 2, Name = "CvBankas" },
                new JobPortal() { Id = 3, Name = "CvLt" });

            modelBuilder.Entity<Tag>().HasData(
                new Tag() { Id = 1, Name = ".NET"},
                new Tag() { Id = 2, Name = "C#" },
                new Tag() { Id = 3, Name = "PHP" },
                new Tag() { Id = 4, Name = "Java" },
                new Tag() { Id = 5, Name = "Javascript" }
            );
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
