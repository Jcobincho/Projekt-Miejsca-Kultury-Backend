using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thirt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Place_PlacesId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PlacesId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PlacesId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "AspNetUsers",
                newName: "AvatarImageId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AvatarImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_AvatarImageId",
                table: "AspNetUsers",
                column: "AvatarImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_AvatarImageId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AvatarImageId",
                table: "AspNetUsers",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AvatarImageId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ImageId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlacesId",
                table: "Images",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PlacesId",
                table: "Images",
                column: "PlacesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Place_PlacesId",
                table: "Images",
                column: "PlacesId",
                principalTable: "Place",
                principalColumn: "Id");
        }
    }
}
