using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concesionaria.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEquipamientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculosEquipamientos",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    EquipamientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculosEquipamientos", x => new { x.VehiculoId, x.EquipamientoId });
                    table.ForeignKey(
                        name: "FK_VehiculosEquipamientos_Equipamientos_EquipamientoId",
                        column: x => x.EquipamientoId,
                        principalTable: "Equipamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehiculosEquipamientos_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiculosEquipamientos_EquipamientoId",
                table: "VehiculosEquipamientos",
                column: "EquipamientoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiculosEquipamientos");

            migrationBuilder.DropTable(
                name: "Equipamientos");
        }
    }
}
