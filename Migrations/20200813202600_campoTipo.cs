using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApi.Migrations
{
    public partial class campoTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsPregunta",
                table: "Chat");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Chat",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Chat");

            migrationBuilder.AddColumn<bool>(
                name: "EsPregunta",
                table: "Chat",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
