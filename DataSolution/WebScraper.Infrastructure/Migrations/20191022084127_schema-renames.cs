using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScraper.Infrastructure.Migrations
{
    public partial class schemarenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblData_PortalPage");

            migrationBuilder.DropTable(
                name: "tblData_PortalType");

            migrationBuilder.CreateTable(
                name: "tblData_JobUrlCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_JobUrlCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblData_JobUrl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_JobUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblData_JobUrl_tblData_JobUrlCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblData_JobUrlCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblData_JobUrlCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "CvOnline.lt" });

            migrationBuilder.CreateIndex(
                name: "IX_tblData_JobUrl_CategoryId",
                table: "tblData_JobUrl",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblData_JobUrl");

            migrationBuilder.DropTable(
                name: "tblData_JobUrlCategory");

            migrationBuilder.CreateTable(
                name: "tblData_PortalType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_PortalType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblData_PortalPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblData_PortalPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblData_PortalPage_tblData_PortalType_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblData_PortalType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblData_PortalType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "CvOnline.lt" });

            migrationBuilder.CreateIndex(
                name: "IX_tblData_PortalPage_CategoryId",
                table: "tblData_PortalPage",
                column: "CategoryId");
        }
    }
}
