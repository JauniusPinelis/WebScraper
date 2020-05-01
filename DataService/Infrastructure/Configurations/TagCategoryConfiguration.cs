using System;
using System.Collections.Generic;
using System.Text;
using Microsoft;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebScraper.Core.Entities;

namespace WebScraper.Infrastructure.Configurations
{
    public class TagCategoryConfiguration : IEntityTypeConfiguration<TagCategory>
    {
        public void Configure([ValidatedNotNullAttribute] EntityTypeBuilder<TagCategory> builder)
        {
            builder.ToTable("tblMeta_tagCategory");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasMaxLength(5)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(500);


        }
    }
}
