using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class addingparserschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "tblData_JobUrl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblData_JobUrl_InfoId",
                table: "tblData_JobUrl",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_JobUrl_JobInfo_InfoId",
                table: "tblData_JobUrl",
                column: "InfoId",
                principalTable: "JobInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_JobUrl_JobInfo_InfoId",
                table: "tblData_JobUrl");

            migrationBuilder.DropTable(
                name: "JobInfo");

            migrationBuilder.DropIndex(
                name: "IX_tblData_JobUrl_InfoId",
                table: "tblData_JobUrl");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "tblData_JobUrl");
        }
    }
}
