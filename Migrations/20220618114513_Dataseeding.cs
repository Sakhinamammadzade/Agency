using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agency.Migrations
{
    public partial class Dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Portfolio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_CategoryId1",
                table: "Portfolio",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_Categories_CategoryId1",
                table: "Portfolio",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_Categories_CategoryId1",
                table: "Portfolio");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_CategoryId1",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Portfolio");
        }
    }
}
