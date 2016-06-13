using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicHistoryTAEN.Migrations
{
    public partial class authorToArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Track");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Track",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Track");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Track",
                nullable: true);
        }
    }
}
