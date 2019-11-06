using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Configurations
{
    public class JobUrlConfiguration : IEntityTypeConfiguration<JobUrl>
    {
        public void Configure(EntityTypeBuilder<JobUrl> builder)
        {
            builder.ToTable("tblData_jobUrl");

            builder.Property(e => e.Id)
               .HasColumnName("Id")
               .HasMaxLength(5)
               .ValueGeneratedOnAdd();

            builder.Property(e => e.Url).HasMaxLength(300);
        }
    }
}
