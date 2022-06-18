using AndreLanches.Context;
using AndreLanches.Models;
using Microsoft.EntityFrameworkCore;

namespace AndreLanches.Areas.Admin.Servicos
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext context;

        public RelatorioVendasService(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<PedidoModel>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= maxDate.Value);
            }

            return await resultado
                           .Include(l => l.PedidoItens)
                           .ThenInclude(l => l.Lanche)
                           .OrderByDescending(x => x.PedidoEnviado)
                           .ToListAsync();
        }
    }
}
