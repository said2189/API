using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Productos",
                columns: table => new
                {
                    Pk_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strDescripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    intEstado = table.Column<int>(type: "int", nullable: false),
                    dtFechaFabricacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtFechaValidez = table.Column<DateTime>(type: "datetime2", nullable: false),
                    strCodigoProveedor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    strDescripcionProveedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    strTelefonoProveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Productos", x => x.Pk_Producto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Productos");
        }
    }
}
