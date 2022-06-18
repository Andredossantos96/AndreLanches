using AndreLanches.Models;

namespace AndreLanches.ViewModels
{
    public class PedidoLancheViewModel
    {
        public PedidoModel Pedido { get; set; }
        public IEnumerable<PedidoDetalheModel> PedidoDetalhes { get; set; }

    }
}
