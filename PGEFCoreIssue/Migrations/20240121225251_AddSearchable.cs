using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGEFCoreIssue.Migrations
{
    public partial class AddSearchable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SearchableIPAddress",
                table: "Test",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                computedColumnSql: "((IPAddress & 255) || '.' || ((IPAddress >> 8) & 255)) || '.' || ((IPAddress >> 16) & 255) || '.' || ((IPAddress >> 24) & 255)",
                stored: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_SearchableIPAddress",
                table: "Test",
                column: "SearchableIPAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Test_SearchableIPAddress",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "SearchableIPAddress",
                table: "Test");
        }
    }
}
