using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserId_To_Places : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Place",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsersId",
                table: "Place",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Place_UsersId",
                table: "Place",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_User_UsersId",
                table: "Place",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_User_UsersId",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Place_UsersId",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Place");
        }
    }
}
