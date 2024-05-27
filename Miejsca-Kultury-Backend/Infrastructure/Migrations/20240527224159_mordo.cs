using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mordo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AvagarImages_AvatarImageId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AvatarImageId",
                table: "AspNetUsers",
                newName: "AvatarimageId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AvatarImageId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AvatarimageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AvagarImages_AvatarimageId",
                table: "AspNetUsers",
                column: "AvatarimageId",
                principalTable: "AvagarImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AvagarImages_AvatarimageId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AvatarimageId",
                table: "AspNetUsers",
                newName: "AvatarImageId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AvatarimageId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AvatarImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AvagarImages_AvatarImageId",
                table: "AspNetUsers",
                column: "AvatarImageId",
                principalTable: "AvagarImages",
                principalColumn: "Id");
        }
    }
}
