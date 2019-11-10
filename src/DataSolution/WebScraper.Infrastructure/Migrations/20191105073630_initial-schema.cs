using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class initialschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblData_jobUrl",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(maxLength: 300, nullable: true),
                    JobInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_jobUrl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblData_jobInfo",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 6, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HtmlCode = table.Column<string>(maxLength: 100000, nullable: true),
                    Title = table.Column<string>(maxLength: 100000, nullable: true),
                    Salary = table.Column<string>(maxLength: 100000, nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobInfo_JobUrlId",
                table: "tblData_jobInfo",
                column: "JobUrlId",
                unique: true,
                filter: "[JobUrlId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblData_jobInfo");

            migrationBuilder.DropTable(
                name: "tblData_jobUrl");
        }
    }
}
