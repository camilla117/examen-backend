using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiCarrito.Data.Migrations
{
    /// <inheritdoc />
    public partial class NombreAddedArticulos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Articulos");
        }
    }
}
