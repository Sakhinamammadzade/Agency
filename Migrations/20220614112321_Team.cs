using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agency.Migrations
{
    public partial class Team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamSocials");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Socials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Socials_TeamId",
                table: "Socials",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Teams_TeamId",
                table: "Socials",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Teams_TeamId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_TeamId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Socials");

            migrationBuilder.CreateTable(
                name: "TeamSocials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSocials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSocials_Socials_SocialId",
                        column: x => x.SocialId,
                        principalTable: "Socials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSocials_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamSocials_SocialId",
                table: "TeamSocials",
                column: "SocialId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSocials_TeamId",
                table: "TeamSocials",
                column: "TeamId");
        }
    }
}
