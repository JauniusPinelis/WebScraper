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
            builder.ToTable("tblMeta_tag");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasMaxLength(5)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}
