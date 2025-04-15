using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prueba_backend.Migrations
{
    /// <inheritdoc />
    public partial class cambiar_agregar_Valores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Productos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Productos");
        }
    }
}
