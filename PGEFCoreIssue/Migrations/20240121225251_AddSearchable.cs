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
                computedColumnSql: "CASE WHEN \"IPAddress\" IS NULL THEN 'NULL'::text ELSE (\"IPAddress\" & 255)::text || '.'::text || ((\"IPAddress\" >> 8) & 255)::text || '.'::text || ((\"IPAddress\" >> 16) & 255)::text || '.'::text || ((\"IPAddress\" >> 24) & 255)::text END",
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
