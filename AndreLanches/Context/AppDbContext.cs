using AndreLanches.Models;
using Microsoft.EntityFrameworkCore;

namespace AndreLanches.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<LancheModel> Lanches { get; set; }
        public DbSet<CarrinhoCompraItemModel> CarrinhoCompraItens { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<PedidoDetalheModel> PedidoDetalhes { get; set; }


    }
}
