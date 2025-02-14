using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiCarrito.Data.Migrations
{
    /// <inheritdoc />
    public partial class CantidadAddedClienteArticulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "ClienteArticulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "ClienteArticulos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "ClienteArticulos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "ClienteArticulos");
        }
    }
}
