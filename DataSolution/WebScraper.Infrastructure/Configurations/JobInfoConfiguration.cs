using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Configurations
{
    public class JobInfoConfiguration : IEntityTypeConfiguration<JobInfo>
    {
        public void Configure(EntityTypeBuilder<JobInfo> builder)
        {
            builder.Property(e => e.Id)
             .HasColumnName("Id")
             .HasMaxLength(5)
             .ValueGeneratedOnAdd();

            builder.Property(e => e.HtmlCode).HasMaxLength(100000);
        }
    }
}
