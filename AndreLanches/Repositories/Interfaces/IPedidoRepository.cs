using AndreLanches.Models;

namespace AndreLanches.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void CriarPedido(PedidoModel pedido);
    }
}
