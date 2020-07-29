using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyRemote.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartySessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    QueuePassword = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerPassword = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentSong = table.Column<string>(type: "TEXT", nullable: true),
                    SongsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartySessions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartySessions");
        }
    }
}
