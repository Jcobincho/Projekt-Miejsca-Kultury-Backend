using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Images_PlacesId",
                table: "Images",
                column: "PlacesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Place_PlacesId",
                table: "Images",
                column: "PlacesId",
                principalTable: "Place",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Place_PlacesId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PlacesId",
                table: "Images");
        }
    }
}
