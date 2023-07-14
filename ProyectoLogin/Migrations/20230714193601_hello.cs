using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLogin.Migrations
{
    /// <inheritdoc />
    public partial class hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    IdActivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.IdActivo);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumEmpleado = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Clave = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__USUARIO__5B65BF97D1F49851", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "ActivoEmpleados",
                columns: table => new
                {
                    IdActivoEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkEmpleado = table.Column<int>(type: "int", nullable: true),
                    FkActivo = table.Column<int>(type: "int", nullable: true),
                    FechaDeAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeLiberacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeEntrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivoEmpleados", x => x.IdActivoEmpleado);
                    table.ForeignKey(
                        name: "FK_ActivoEmpleados_Activos_FkActivo",
                        column: x => x.FkActivo,
                        principalTable: "Activos",
                        principalColumn: "IdActivo");
                    table.ForeignKey(
                        name: "FK_ActivoEmpleados_Empleados_FkEmpleado",
                        column: x => x.FkEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IdEmpleado");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivoEmpleados_FkActivo",
                table: "ActivoEmpleados",
                column: "FkActivo");

            migrationBuilder.CreateIndex(
                name: "IX_ActivoEmpleados_FkEmpleado",
                table: "ActivoEmpleados",
                column: "FkEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivoEmpleados");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
