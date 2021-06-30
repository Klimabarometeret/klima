using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransformSsbBlobToSQL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ssb07849s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Region = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeKjøring = table.Column<string>(type: "TEXT", nullable: true),
                    Drivstofftype = table.Column<string>(type: "TEXT", nullable: true),
                    År = table.Column<int>(type: "INTEGER", nullable: false),
                    Biltype = table.Column<string>(type: "TEXT", nullable: true),
                    Antall = table.Column<int>(type: "INTEGER", nullable: false),
                    Dato = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ssb07849s", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ssb07849s");
        }
    }
}
