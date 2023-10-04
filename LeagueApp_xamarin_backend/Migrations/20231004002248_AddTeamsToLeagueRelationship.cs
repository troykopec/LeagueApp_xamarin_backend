using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueApp_xamarin_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamsToLeagueRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_TeamLeaderId",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "LeagueId1",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeagueId1",
                table: "Teams",
                column: "LeagueId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Leagues_LeagueId1",
                table: "Teams",
                column: "LeagueId1",
                principalTable: "Leagues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_TeamLeaderId",
                table: "Teams",
                column: "TeamLeaderId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Leagues_LeagueId1",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_TeamLeaderId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LeagueId1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LeagueId1",
                table: "Teams");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_TeamLeaderId",
                table: "Teams",
                column: "TeamLeaderId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
