using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tblData_tag");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasMaxLength(5)
                .ValueGeneratedOnAdd();

            builder.HasOne(e => e.JobInfo)
                .WithMany(p => p.Tags)
                .HasForeignKey(e => e.JobInfoId);

            builder.HasOne(e => e.TagCategory)
                .WithMany(p => p.Tags)
                .HasForeignKey(e => e.TagCategoryId);

        }
    }
}
