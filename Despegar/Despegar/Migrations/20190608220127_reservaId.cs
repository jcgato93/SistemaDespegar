using Microsoft.EntityFrameworkCore.Migrations;

namespace Despegar.Migrations
{
    public partial class reservaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservas",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
