using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using System.Linq;

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

            builder.HasOne(u => u.JobUrl)
                .WithOne(i => i.JobInfo)
                .HasForeignKey<JobInfo>(u => u.JobUrlId)
                .HasConstraintName("FK_tblData_JobInfo_tblDataUrl")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
