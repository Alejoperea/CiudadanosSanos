using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CiudadanosSanos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtencionMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamePaciente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionMedicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtencionMedicaPaciente",
                columns: table => new
                {
                    AtencionMedicasId = table.Column<int>(type: "int", nullable: false),
                    PacientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionMedicaPaciente", x => new { x.AtencionMedicasId, x.PacientesId });
                    table.ForeignKey(
                        name: "FK_AtencionMedicaPaciente_AtencionMedicas_AtencionMedicasId",
                        column: x => x.AtencionMedicasId,
                        principalTable: "AtencionMedicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtencionMedicaPaciente_Pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtencionMedicaPaciente_PacientesId",
                table: "AtencionMedicaPaciente",
                column: "PacientesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtencionMedicaPaciente");

            migrationBuilder.DropTable(
                name: "AtencionMedicas");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
