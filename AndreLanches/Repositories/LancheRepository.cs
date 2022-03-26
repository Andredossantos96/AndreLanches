using AndreLanches.Context;
using AndreLanches.Models;
using AndreLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AndreLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<LancheModel> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<LancheModel> LanchesPreferidos => _context.Lanches.
                                        Where(l => l.IsLanchePreferido)
                                        .Include(c => c.Categoria);

        public LancheModel GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
        }
    }
}
