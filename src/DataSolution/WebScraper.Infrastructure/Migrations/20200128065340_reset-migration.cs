using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class resetmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblData_salary",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    From = table.Column<decimal>(nullable: true),
                    To = table.Column<decimal>(nullable: true),
                    Exact = table.Column<decimal>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    JObUrlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_salary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMeta_jobPortal",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMeta_jobPortal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMeta_tagCategory",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMeta_tagCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblData_jobUrl",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(maxLength: 300, nullable: true),
                    SalaryText = table.Column<string>(maxLength: 500, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    JobInfoId = table.Column<int>(nullable: true),
                    JobPortalId = table.Column<int>(nullable: true),
                    SalaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_jobUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblData_jobUrl_tblMeta_jobPortal_JobInfoId",
                        column: x => x.JobInfoId,
                        principalTable: "tblMeta_jobPortal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblData_jobUrl_tblData_salary_SalaryId",
                        column: x => x.SalaryId,
                        principalTable: "tblData_salary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblData_jobInfo",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    HtmlCode = table.Column<string>(maxLength: 100000, nullable: true),
                    Title = table.Column<string>(maxLength: 100000, nullable: true),
                    SalaryText = table.Column<string>(maxLength: 100000, nullable: true),
                    JobUrlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_jobInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblData_JobInfo_tblDataUrl",
                        column: x => x.JobUrlId,
                        principalTable: "tblData_jobUrl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblData_tag",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagCategoryId = table.Column<int>(nullable: false),
                    JobInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblData_tag_tblData_jobInfo_JobInfoId",
                        column: x => x.JobInfoId,
                        principalTable: "tblData_jobInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblData_tag_tblMeta_tagCategory_TagCategoryId",
                        column: x => x.TagCategoryId,
                        principalTable: "tblMeta_tagCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblMeta_jobPortal",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CvOnline" },
                    { 2, "CvBankas" },
                    { 3, "CvLt" }
                });

            migrationBuilder.InsertData(
                table: "tblMeta_tagCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, ".NET" },
                    { 2, "C#" },
                    { 3, "PHP" },
                    { 4, "Java" },
                    { 5, "Javascript" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobInfo_JobUrlId",
                table: "tblData_jobInfo",
                column: "JobUrlId",
                unique: true,
                filter: "[JobUrlId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobUrl_JobInfoId",
                table: "tblData_jobUrl",
                column: "JobInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobUrl_SalaryId",
                table: "tblData_jobUrl",
                column: "SalaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblData_tag_JobInfoId",
                table: "tblData_tag",
                column: "JobInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblData_tag_TagCategoryId",
                table: "tblData_tag",
                column: "TagCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblData_tag");

            migrationBuilder.DropTable(
                name: "tblData_jobInfo");

            migrationBuilder.DropTable(
                name: "tblMeta_tagCategory");

            migrationBuilder.DropTable(
                name: "tblData_jobUrl");

            migrationBuilder.DropTable(
                name: "tblMeta_jobPortal");

            migrationBuilder.DropTable(
                name: "tblData_salary");
        }
    }
}
