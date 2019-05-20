using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Despegar.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CuartoId = table.Column<int>(nullable: false),
                    FechaReserva = table.Column<DateTime>(nullable: false),
                    DiasReserva = table.Column<int>(nullable: false),
                    CantidadPersonas = table.Column<int>(nullable: false),
                    NombreCliente = table.Column<string>(nullable: false),
                    IdentificacionCliente = table.Column<int>(nullable: false),
                    Hotel = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
