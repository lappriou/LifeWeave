using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeWeave.Apps.BlazorApp.Migrations;

/// <inheritdoc />
public partial class _20261121093601_Taxons_Rename_Taxa : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Taxons");

        migrationBuilder.CreateTable(
            name: "Taxa",
            columns: table => new
            {
                ID = table.Column<Guid>(type: "uuid", nullable: false),
                NameScientific = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Taxa", x => x.ID);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Taxa");

        migrationBuilder.CreateTable(
            name: "Taxons",
            columns: table => new
            {
                ID = table.Column<Guid>(type: "uuid", nullable: false),
                NameScientific = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Taxons", x => x.ID);
            });
    }
}
