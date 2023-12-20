using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace @event.Migrations
{
    /// <inheritdoc />
    public partial class maxPar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxParticipant",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxParticipant",
                table: "Events");
        }
    }
}
