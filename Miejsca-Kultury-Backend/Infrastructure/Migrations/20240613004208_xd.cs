using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class xd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AverageRating");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Place");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AverageRating",
                table: "Place",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AverageRating",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlacesId = table.Column<Guid>(type: "uuid", nullable: false),
                    AverageRating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AverageRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AverageRating_Place_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AverageRating_PlacesId",
                table: "AverageRating",
                column: "PlacesId");
        }
    }
}
