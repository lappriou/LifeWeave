using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeWeave.Apps.BlazorApp.Migrations;

/// <inheritdoc />
public partial class _20261123154458_Taxons_Columns_COLID_Create : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ColID",
            table: "Taxa",
            type: "text",
            nullable: false,
            defaultValue: "");

        migrationBuilder.CreateIndex(
            name: "IX_Taxa_ColID",
            table: "Taxa",
            column: "ColID",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Taxa_ColID",
            table: "Taxa");

        migrationBuilder.DropColumn(
            name: "ColID",
            table: "Taxa");
    }
}
