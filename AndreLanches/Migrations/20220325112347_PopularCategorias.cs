using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreLanches.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
                "VALUES('Normal','Lanche feito com ingrediantes normais')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao)" +
                "VALUES('Natural','Lanche feito com ingrediantes integrais e naturais')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
