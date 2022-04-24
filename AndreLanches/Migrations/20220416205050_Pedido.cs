using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreLanches.Migrations
{
    public partial class Pedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereço2",
                table: "Pedidos",
                newName: "Endereco2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Endereco2",
                table: "Pedidos",
                newName: "Endereço2");
        }
    }
}
