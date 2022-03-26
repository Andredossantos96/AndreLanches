using AndreLanches.Context;
using AndreLanches.Models;
using AndreLanches.Repositories.Interfaces;

namespace AndreLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoriaModel> Categorias => _context.Categorias;
    }
}
