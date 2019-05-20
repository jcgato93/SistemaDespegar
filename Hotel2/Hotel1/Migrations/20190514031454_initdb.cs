using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel1.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeCuartos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeCuartos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuartos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NumeroHabitacion = table.Column<string>(nullable: false),
                    TipoDeCuartoId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuartos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuartos_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuartos_TipoDeCuartos_TipoDeCuartoId",
                        column: x => x.TipoDeCuartoId,
                        principalTable: "TipoDeCuartos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CuartoId = table.Column<int>(nullable: false),
                    FechaReserva = table.Column<DateTime>(nullable: false),
                    DiasReserva = table.Column<int>(nullable: false),
                    CantidadPersonas = table.Column<int>(nullable: false),
                    NombreCliente = table.Column<string>(nullable: false),
                    IdentificacionCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Cuartos_CuartoId",
                        column: x => x.CuartoId,
                        principalTable: "Cuartos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuartos_StatusId",
                table: "Cuartos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuartos_TipoDeCuartoId",
                table: "Cuartos",
                column: "TipoDeCuartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CuartoId",
                table: "Reservas",
                column: "CuartoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Cuartos");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TipoDeCuartos");
        }
    }
}
