using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prueba_backend.Migrations
{
    /// <inheritdoc />
    public partial class aggFechaIngreso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Bodega_BodegaId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bodega",
                table: "Bodega");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Bodega",
                newName: "Bodegas");

            migrationBuilder.AlterColumn<int>(
                name: "BodegaId",
                table: "Productos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "Productos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bodegas",
                table: "Bodegas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Bodegas_BodegaId",
                table: "Productos",
                column: "BodegaId",
                principalTable: "Bodegas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Bodegas_BodegaId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bodegas",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Bodegas",
                newName: "Bodega");

            migrationBuilder.AlterColumn<int>(
                name: "BodegaId",
                table: "Productos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Productos",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bodega",
                table: "Bodega",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Bodega_BodegaId",
                table: "Productos",
                column: "BodegaId",
                principalTable: "Bodega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
