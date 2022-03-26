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
    }
}
