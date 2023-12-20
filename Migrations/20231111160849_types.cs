using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace @event.Migrations
{
    /// <inheritdoc />
    public partial class types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TypeEvnId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Events_TypeEvnId",
                table: "Events",
                column: "TypeEvnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Types_TypeEvnId",
                table: "Events",
                column: "TypeEvnId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Types_TypeEvnId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_TypeEvnId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TypeEvnId",
                table: "Events");
        }
    }
}
