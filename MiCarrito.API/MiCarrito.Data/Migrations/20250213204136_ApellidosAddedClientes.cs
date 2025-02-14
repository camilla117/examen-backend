using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiCarrito.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApellidosAddedClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Clientes");
        }
    }
}
