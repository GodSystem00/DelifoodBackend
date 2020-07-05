using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delifood.Migrations
{
    public partial class CreateDelifood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Usuario = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "mercados",
                columns: table => new
                {
                    MercadoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    latitud = table.Column<float>(nullable: false),
                    longitud = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mercados", x => x.MercadoID);
                });

            migrationBuilder.CreateTable(
                name: "vendedors",
                columns: table => new
                {
                    VendedorID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    DNI = table.Column<string>(nullable: true),
                    MercadoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedors", x => x.VendedorID);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    CompraID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    codigo = table.Column<string>(nullable: true),
                    Importe = table.Column<float>(nullable: false),
                    ConFactura = table.Column<bool>(nullable: false),
                    ConBoleta = table.Column<bool>(nullable: false),
                    SoloEfectivo = table.Column<bool>(nullable: false),
                    ClienteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.CompraID);
                    table.ForeignKey(
                        name: "FK_compras_clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    categoria = table.Column<string>(nullable: true),
                    Precio = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    VendedorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_productos_vendedors_VendedorID",
                        column: x => x.VendedorID,
                        principalTable: "vendedors",
                        principalColumn: "VendedorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "compramercados",
                columns: table => new
                {
                    CompraMercadoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompraID = table.Column<int>(nullable: false),
                    MercadoID = table.Column<int>(nullable: false),
                    ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compramercados", x => x.CompraMercadoID);
                    table.ForeignKey(
                        name: "FK_compramercados_clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_compramercados_compras_CompraID",
                        column: x => x.CompraID,
                        principalTable: "compras",
                        principalColumn: "CompraID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compramercados_mercados_MercadoID",
                        column: x => x.MercadoID,
                        principalTable: "mercados",
                        principalColumn: "MercadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compramercados_ClienteID",
                table: "compramercados",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_compramercados_CompraID",
                table: "compramercados",
                column: "CompraID");

            migrationBuilder.CreateIndex(
                name: "IX_compramercados_MercadoID",
                table: "compramercados",
                column: "MercadoID");

            migrationBuilder.CreateIndex(
                name: "IX_compras_ClienteID",
                table: "compras",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_productos_VendedorID",
                table: "productos",
                column: "VendedorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compramercados");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "mercados");

            migrationBuilder.DropTable(
                name: "vendedors");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
