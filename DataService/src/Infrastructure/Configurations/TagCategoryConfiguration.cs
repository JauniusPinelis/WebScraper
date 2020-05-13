using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infrastructure.Configurations
{
    public class TagCategoryConfiguration : IEntityTypeConfiguration<TagCategory>
    {
        public void Configure(EntityTypeBuilder<TagCategory> builder)
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
