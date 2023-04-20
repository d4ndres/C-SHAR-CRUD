using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _02_learn_entity_framework_core.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Description", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("266970ac-6a58-4c4d-b9b3-f9ccfd976e94"), "Cortar pelo", "Actividades personales", 10 },
                    { new Guid("766970ac-6a58-4c4d-b9b3-f9ccfd976e94"), "Sacar al perro, ir de compras y salvar el mundo", "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Description", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("762370ac-6a58-4c4d-b9b3-f9ccfd976e92"), new Guid("766970ac-6a58-4c4d-b9b3-f9ccfd976e94"), null, new DateTime(2023, 4, 19, 21, 24, 40, 870, DateTimeKind.Local).AddTicks(1516), 0, "Ver pelicula" },
                    { new Guid("762370ac-6a58-4c4d-b9b3-f9ccfd976e94"), new Guid("766970ac-6a58-4c4d-b9b3-f9ccfd976e94"), null, new DateTime(2023, 4, 19, 21, 24, 40, 870, DateTimeKind.Local).AddTicks(1501), 1, "Pago de servicios" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("266970ac-6a58-4c4d-b9b3-f9ccfd976e94"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("762370ac-6a58-4c4d-b9b3-f9ccfd976e92"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("762370ac-6a58-4c4d-b9b3-f9ccfd976e94"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("766970ac-6a58-4c4d-b9b3-f9ccfd976e94"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
