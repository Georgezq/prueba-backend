using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace prueba_backend.Migrations
{
    /// <inheritdoc />
    public partial class aggBodega_aggFkEnProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodegaId",
                table: "Productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bodega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_BodegaId",
                table: "Productos",
                column: "BodegaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Bodega_BodegaId",
                table: "Productos",
                column: "BodegaId",
                principalTable: "Bodega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Bodega_BodegaId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Bodega");

            migrationBuilder.DropIndex(
                name: "IX_Productos_BodegaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "BodegaId",
                table: "Productos");
        }
    }
}
