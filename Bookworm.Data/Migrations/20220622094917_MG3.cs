using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm.Data.Migrations
{
    public partial class MG3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "CommantBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comment",
                table: "CommantBooks");
        }
    }
}
