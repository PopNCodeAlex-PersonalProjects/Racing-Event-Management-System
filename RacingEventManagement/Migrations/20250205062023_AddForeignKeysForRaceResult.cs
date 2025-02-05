using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RacingEventManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeysForRaceResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RacesResults",
                columns: table => new
                {
                    RaceResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FinishTime = table.Column<double>(type: "double", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: true),
                    RaceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacesResults", x => x.RaceResultId);
                    table.ForeignKey(
                        name: "FK_RacesResults_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId");
                    table.ForeignKey(
                        name: "FK_RacesResults_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "RaceId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RacesResults_ParticipantId",
                table: "RacesResults",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_RacesResults_RaceId",
                table: "RacesResults",
                column: "RaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RacesResults");
        }
    }
}
