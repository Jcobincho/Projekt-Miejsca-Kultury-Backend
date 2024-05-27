using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class czwartaXD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_AvatarImageId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "AvagarImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvagarImages",
                table: "AvagarImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    TotalBytes = table.Column<long>(type: "bigint", nullable: false),
                    S3Key = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    PlacesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImages_Place_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PlacesId",
                table: "PostImages",
                column: "PlacesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AvagarImages_AvatarImageId",
                table: "AspNetUsers",
                column: "AvatarImageId",
                principalTable: "AvagarImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AvagarImages_AvatarImageId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvagarImages",
                table: "AvagarImages");

            migrationBuilder.RenameTable(
                name: "AvagarImages",
                newName: "Images");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_AvatarImageId",
                table: "AspNetUsers",
                column: "AvatarImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
