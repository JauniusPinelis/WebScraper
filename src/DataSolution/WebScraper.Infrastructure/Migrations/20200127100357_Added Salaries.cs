using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class AddedSalaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "tblData_jobInfo");

            migrationBuilder.AddColumn<int>(
                name: "SalaryId",
                table: "tblData_jobInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SalaryText",
                table: "tblData_jobInfo",
                maxLength: 100000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblData_salary",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 5, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<decimal>(nullable: true),
                    To = table.Column<decimal>(nullable: true),
                    Exact = table.Column<decimal>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    JobInfoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_salary", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblData_jobInfo_SalaryId",
                table: "tblData_jobInfo",
                column: "SalaryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblData_jobInfo_tblData_salary_SalaryId",
                table: "tblData_jobInfo",
                column: "SalaryId",
                principalTable: "tblData_salary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblData_jobInfo_tblData_salary_SalaryId",
                table: "tblData_jobInfo");

            migrationBuilder.DropTable(
                name: "tblData_salary");

            migrationBuilder.DropIndex(
                name: "IX_tblData_jobInfo_SalaryId",
                table: "tblData_jobInfo");

            migrationBuilder.DropColumn(
                name: "SalaryId",
                table: "tblData_jobInfo");

            migrationBuilder.DropColumn(
                name: "SalaryText",
                table: "tblData_jobInfo");

            migrationBuilder.AddColumn<string>(
                name: "Salary",
                table: "tblData_jobInfo",
                type: "nvarchar(max)",
                maxLength: 100000,
                nullable: true);
        }
    }
}
