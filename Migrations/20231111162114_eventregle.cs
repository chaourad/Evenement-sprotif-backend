using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace @event.Migrations
{
    /// <inheritdoc />
    public partial class eventregle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Regle",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Regle",
                table: "Events");
        }
    }
}
