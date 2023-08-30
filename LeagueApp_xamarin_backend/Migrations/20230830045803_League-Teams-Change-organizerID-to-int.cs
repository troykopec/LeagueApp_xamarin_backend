using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueApp_xamarin_backend.Migrations
{
    /// <inheritdoc />
    public partial class LeagueTeamsChangeorganizerIDtoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrganizerId",
                table: "Leagues",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_OrganizerId",
                table: "Leagues",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Users_OrganizerId",
                table: "Leagues",
                column: "OrganizerId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Users_OrganizerId",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_OrganizerId",
                table: "Leagues");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
