using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicHistoryTAEN.Migrations
{
    public partial class renameUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_UserId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Artist");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.AddColumn<int>(
                name: "UsersUserId",
                table: "Artist",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_UsersUserId",
                table: "Artist",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Users_UsersUserId",
                table: "Artist",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Users_UsersUserId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_UsersUserId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "UsersUserId",
                table: "Artist");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Artist",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_UserId",
                table: "Artist",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_User_UserId",
                table: "Artist",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
