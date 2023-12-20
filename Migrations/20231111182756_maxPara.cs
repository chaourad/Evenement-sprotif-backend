using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace @event.Migrations
{
    /// <inheritdoc />
    public partial class maxPara : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreParticipant",
                table: "Events",
                newName: "NombreParticipantActuel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreParticipantActuel",
                table: "Events",
                newName: "NombreParticipant");
        }
    }
}
