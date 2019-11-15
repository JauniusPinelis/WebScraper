using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class addingjobportals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "tblMeta_jobPortal",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "CvOnline" });

            migrationBuilder.InsertData(
                table: "tblMeta_jobPortal",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "CvBankas" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblMeta_jobPortal");
        }
    }
}
