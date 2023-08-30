using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueApp_xamarin_backend.Migrations
{
    /// <inheritdoc />
    public partial class LeagueTeamsChangetoonlyorganizerID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Users_OrganizerUserID",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_OrganizerUserID",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "OrganizerUserID",
                table: "Leagues");

            migrationBuilder.AddColumn<string>(
                name: "OrganizerId",
                table: "Leagues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Leagues");

            migrationBuilder.AddColumn<int>(
                name: "OrganizerUserID",
                table: "Leagues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_OrganizerUserID",
                table: "Leagues",
                column: "OrganizerUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Users_OrganizerUserID",
                table: "Leagues",
                column: "OrganizerUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
