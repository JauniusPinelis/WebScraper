﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebScraper.Infrastructure.Db;

namespace WebScraper.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebScraper.Core.Entities.JobInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(6)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("HtmlCode")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(100000);

                    b.Property<int?>("JobUrlId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SalaryText")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(100000);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(100000);

                    b.HasKey("Id");

                    b.HasIndex("JobUrlId")
                        .IsUnique()
                        .HasFilter("[JobUrlId] IS NOT NULL");

                    b.ToTable("tblData_jobInfo");
                });

            modelBuilder.Entity("WebScraper.Core.Entities.JobPortal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(5)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("tblMeta_jobPortal");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CvOnline"
                        },
                        new
                        {
                            Id = 2,
                            Name = "CvBankas"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CvLt"
                        });
                });

            modelBuilder.Entity("WebScraper.Core.Entities.JobUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(5)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("JobInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("JobPortalId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int?>("SalaryId")
                        .HasColumnType("int");

                    b.Property<string>("SalaryText")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("JobInfoId");

                    b.HasIndex("SalaryId")
                        .IsUnique()
                        .HasFilter("[SalaryId] IS NOT NULL");

                    b.ToTable("tblData_jobUrl");
                });

            modelBuilder.Entity("WebScraper.Core.Entities.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(5)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Exact")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("From")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("JObUrlId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Period")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("To")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblData_salary");
                });

            modelBuilder.Entity("WebScraper.Core.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(5)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobInfoId")
                        .HasColumnType("int");

                    b.Property<int>("TagCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobInfoId");

                    b.HasIndex("TagCategoryId");

                    b.ToTable("tblData_tag");
                });

            modelBuilder.Entity("WebScraper.Core.Entities.TagCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasMaxLength(5)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("tblMeta_tagCategory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = ".NET"
                        },
                        new
                        {
                            Id = 2,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 3,
                            Name = "PHP"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Javascript"
                        },
                        new
                        {
                            Id = 6,
                            Name = "React"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Angular"
                        },
                        new
                        {
                            Id = 8,
                            Name = "React"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Node.js"
                        });
                });

            modelBuilder.Entity("WebScraper.Core.Entities.JobInfo", b =>
                {
                    b.HasOne("WebScraper.Core.Entities.JobUrl", "JobUrl")
                        .WithOne("JobInfo")
                        .HasForeignKey("WebScraper.Core.Entities.JobInfo", "JobUrlId")
                        .HasConstraintName("FK_tblData_JobInfo_tblDataUrl")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebScraper.Core.Entities.JobUrl", b =>
                {
                    b.HasOne("WebScraper.Core.Entities.JobPortal", "JobPortal")
                        .WithMany("JobUrls")
                        .HasForeignKey("JobInfoId");

                    b.HasOne("WebScraper.Core.Entities.Salary", "Salary")
                        .WithOne("JobUrl")
                        .HasForeignKey("WebScraper.Core.Entities.JobUrl", "SalaryId");
                });

            modelBuilder.Entity("WebScraper.Core.Entities.Tag", b =>
                {
                    b.HasOne("WebScraper.Core.Entities.JobInfo", "JobInfo")
                        .WithMany("Tags")
                        .HasForeignKey("JobInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebScraper.Core.Entities.TagCategory", "TagCategory")
                        .WithMany("Tags")
                        .HasForeignKey("TagCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
