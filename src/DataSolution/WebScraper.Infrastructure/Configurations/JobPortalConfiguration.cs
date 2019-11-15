using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Configurations
{
    public class JobPortalConfiguration : IEntityTypeConfiguration<JobPortal>
    {
        public void Configure(EntityTypeBuilder<JobPortal> builder)
        {
            builder.ToTable("tblMeta_jobPortal");

            builder.Property(e => e.Id)
               .HasColumnName("Id")
               .HasMaxLength(5)
               .ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}
