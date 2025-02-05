using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RacingEventManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddRefrencesInRaceResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RacesResults_Participants_ParticipantId",
                table: "RacesResults");

            migrationBuilder.DropForeignKey(
                name: "FK_RacesResults_Races_RaceId",
                table: "RacesResults");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "RacesResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantId",
                table: "RacesResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RacesResults_Participants_ParticipantId",
                table: "RacesResults",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "ParticipantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacesResults_Races_RaceId",
                table: "RacesResults",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RacesResults_Participants_ParticipantId",
                table: "RacesResults");

            migrationBuilder.DropForeignKey(
                name: "FK_RacesResults_Races_RaceId",
                table: "RacesResults");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "RacesResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantId",
                table: "RacesResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RacesResults_Participants_ParticipantId",
                table: "RacesResults",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RacesResults_Races_RaceId",
                table: "RacesResults",
                column: "RaceId",
                principalTable: "Races",
                principalColumn: "RaceId");
        }
    }
}
