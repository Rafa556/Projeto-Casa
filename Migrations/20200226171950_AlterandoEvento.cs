using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyHome.Migrations
{
    public partial class AlterandoEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Local",
                table: "Eventos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Eventos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
