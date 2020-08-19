using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApi.Migrations
{
    public partial class notificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificacionCabecera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Texto = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Para = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacionCabecera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificacionCabecera_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificacionDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabeceraId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    MascotaId = table.Column<int>(nullable: false),
                    Leido = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacionDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificacionDetalle_NotificacionCabecera_CabeceraId",
                        column: x => x.CabeceraId,
                        principalTable: "NotificacionCabecera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NotificacionDetalle_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NotificacionDetalle_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificacionCabecera_UsuarioId",
                table: "NotificacionCabecera",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacionDetalle_CabeceraId",
                table: "NotificacionDetalle",
                column: "CabeceraId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacionDetalle_ClienteId",
                table: "NotificacionDetalle",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacionDetalle_MascotaId",
                table: "NotificacionDetalle",
                column: "MascotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificacionDetalle");

            migrationBuilder.DropTable(
                name: "NotificacionCabecera");
        }
    }
}
