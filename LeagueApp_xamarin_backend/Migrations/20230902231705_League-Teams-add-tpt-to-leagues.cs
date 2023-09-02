using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeagueApp_xamarin_backend.Migrations
{
    /// <inheritdoc />
    public partial class LeagueTeamsaddtpttoleagues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketballLeagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketballLeagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketballLeagues_Leagues_Id",
                        column: x => x.Id,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NicheLeagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NichePoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NicheLeagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NicheLeagues_Leagues_Id",
                        column: x => x.Id,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoccerLeagues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoccerLeagues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoccerLeagues_Leagues_Id",
                        column: x => x.Id,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketballLeagues");

            migrationBuilder.DropTable(
                name: "NicheLeagues");

            migrationBuilder.DropTable(
                name: "SoccerLeagues");
        }
    }
}
