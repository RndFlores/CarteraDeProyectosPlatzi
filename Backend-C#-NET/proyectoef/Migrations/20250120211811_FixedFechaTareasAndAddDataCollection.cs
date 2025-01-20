using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class FixedFechaTareasAndAddDataCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("f41a95e0-c087-4fa2-9e36-2bc00c959e01"), "Actividades realcionadas con el ámbito personal", "Actividades Personales", 50 },
                    { new Guid("f41a95e0-c087-4fa2-9e36-2bc00c959e4f"), "Tareas que aún no han sido completadas", "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("3b490b5b-4f04-4fe3-97c7-515d53370818"), new Guid("f41a95e0-c087-4fa2-9e36-2bc00c959e01"), "Acabemos la serie yei!!", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Terminar de ver mi serie" },
                    { new Guid("3b490b5b-4f04-4fe3-97c7-515d53370857"), new Guid("f41a95e0-c087-4fa2-9e36-2bc00c959e4f"), "Debo pagar los servicio publicos que tengo pendiente", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3b490b5b-4f04-4fe3-97c7-515d53370818"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3b490b5b-4f04-4fe3-97c7-515d53370857"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f41a95e0-c087-4fa2-9e36-2bc00c959e01"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("f41a95e0-c087-4fa2-9e36-2bc00c959e4f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
