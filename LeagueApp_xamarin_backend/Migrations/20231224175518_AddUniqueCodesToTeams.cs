using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueApp_xamarin_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueCodesToTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "Teams");
        }
    }
}
