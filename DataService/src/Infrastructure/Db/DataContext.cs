using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Core.Entities;
using Infrastructure.Services;

namespace Infrastructure.Db
{
    public class DataContext : DbContext, IDataContext
    {

        public DbSet<JobUrl> JobUrls { get; set; }
        public DbSet<JobInfo> JobInfos { get; set; }
        public DbSet<JobPortal> JobPortals { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Salary> Salaries { get; set; }
       

        private readonly IDateTime _dateTime;

        public DataContext() : base()
        {

        }

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

            modelBuilder.Entity<TagCategory>().HasData(
                new TagCategory() { Id = 1, Name = ".NET"},
                new TagCategory() { Id = 2, Name = "C#" },
                new TagCategory() { Id = 3, Name = "PHP" },
                new TagCategory() { Id = 4, Name = "Java" },
                new TagCategory() { Id = 5, Name = "Javascript" },
                new TagCategory() { Id = 6, Name = "React"},
                new TagCategory() { Id = 7, Name = "Angular" },
                new TagCategory() { Id = 8, Name = "React" },
                new TagCategory() { Id = 9, Name = "Node.js" }

            );

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                 .AddJsonFile("appsettings.json")
                 .Build();

                optionsBuilder.UseSqlServer(configuration["DefaultConnection"]);
            }
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
