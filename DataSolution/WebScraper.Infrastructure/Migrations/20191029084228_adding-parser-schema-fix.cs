using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class addingparserschemafix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_JobUrl_JobInfo_InfoId",
                table: "tblData_JobUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobInfo",
                table: "JobInfo");

            migrationBuilder.RenameTable(
                name: "JobInfo",
                newName: "tblData_JonInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblData_JonInfo",
                table: "tblData_JonInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_JobUrl_tblData_JonInfo_InfoId",
                table: "tblData_JobUrl",
                column: "InfoId",
                principalTable: "tblData_JonInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_JobUrl_tblData_JonInfo_InfoId",
                table: "tblData_JobUrl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblData_JonInfo",
                table: "tblData_JonInfo");

            migrationBuilder.RenameTable(
                name: "tblData_JonInfo",
                newName: "JobInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobInfo",
                table: "JobInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_JobUrl_JobInfo_InfoId",
                table: "tblData_JobUrl",
                column: "InfoId",
                principalTable: "JobInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
