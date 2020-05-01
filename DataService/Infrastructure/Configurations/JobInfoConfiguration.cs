using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebScraper.Core.Entities;
using System.Linq;
using Microsoft;

namespace WebScraper.Infrastructure.Configurations
{
    public class JobInfoConfiguration : IEntityTypeConfiguration<JobInfo>
    {
        public void Configure([ValidatedNotNullAttribute] EntityTypeBuilder<JobInfo> builder)
        {
            builder.ToTable("tblData_jobInfo");

            builder.Property(e => e.Id)
             .HasColumnName("Id")
             .HasMaxLength(6)
             .ValueGeneratedOnAdd();

            builder.Property(e => e.HtmlCode).HasMaxLength(100000);
            builder.Property(e => e.Title).HasMaxLength(100000);
            builder.Property(e => e.SalaryText).HasMaxLength(100000);

            builder.HasOne(u => u.JobUrl)
                .WithOne(i => i.JobInfo)
                .HasForeignKey<JobInfo>(u => u.JobUrlId)
                .HasConstraintName("FK_tblData_JobInfo_tblDataUrl")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Tags);
        }
    }
}
