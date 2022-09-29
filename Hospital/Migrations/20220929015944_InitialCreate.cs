using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubAreaName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Documento = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubAreaxArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    SubAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAreaxArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubAreaxArea_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubAreaxArea_SubArea_SubAreaId",
                        column: x => x.SubAreaId,
                        principalTable: "SubArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.direccion);
                    table.ForeignKey(
                        name: "FK_Direccion_Empleados_EmpleadosId",
                        column: x => x.EmpleadosId,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_EmpleadosId",
                table: "Direccion",
                column: "EmpleadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_AreaId",
                table: "Empleados",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAreaxArea_AreaId",
                table: "SubAreaxArea",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubAreaxArea_SubAreaId",
                table: "SubAreaxArea",
                column: "SubAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "SubAreaxArea");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "SubArea");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
