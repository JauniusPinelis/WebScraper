using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class SalaryIdFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_jobUrl_tblData_salary_SalaryId",
                table: "tblData_jobUrl");

            migrationBuilder.DropIndex(
                name: "IX_tblData_jobUrl_SalaryId",
                table: "tblData_jobUrl");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "tblData_jobUrl",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobUrl_SalaryId",
                table: "tblData_jobUrl",
                column: "SalaryId",
                unique: true,
                filter: "[SalaryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_jobUrl_tblData_salary_SalaryId",
                table: "tblData_jobUrl",
                column: "SalaryId",
                principalTable: "tblData_salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_jobUrl_tblData_salary_SalaryId",
                table: "tblData_jobUrl");

            migrationBuilder.DropIndex(
                name: "IX_tblData_jobUrl_SalaryId",
                table: "tblData_jobUrl");

            migrationBuilder.AlterColumn<int>(
                name: "SalaryId",
                table: "tblData_jobUrl",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobUrl_SalaryId",
                table: "tblData_jobUrl",
                column: "SalaryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_jobUrl_tblData_salary_SalaryId",
                table: "tblData_jobUrl",
                column: "SalaryId",
                principalTable: "tblData_salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
