using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApi.Migrations
{
    public partial class nullableMascota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificacionDetalle_Mascotas_MascotaId",
                table: "NotificacionDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "MascotaId",
                table: "NotificacionDetalle",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificacionDetalle_Mascotas_MascotaId",
                table: "NotificacionDetalle",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificacionDetalle_Mascotas_MascotaId",
                table: "NotificacionDetalle");

            migrationBuilder.AlterColumn<int>(
                name: "MascotaId",
                table: "NotificacionDetalle",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificacionDetalle_Mascotas_MascotaId",
                table: "NotificacionDetalle",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
