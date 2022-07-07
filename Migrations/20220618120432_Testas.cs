using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agency.Migrations
{
    public partial class Testas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_Categories_CategoryId1",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_CategoryId1",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Portfolio");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Portfolio",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_CategoryId",
                table: "Portfolio",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_Categories_CategoryId",
                table: "Portfolio",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_Categories_CategoryId",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_CategoryId",
                table: "Portfolio");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Portfolio",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId1",
                table: "Portfolio",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
