using System.ComponentModel.DataAnnotations;

namespace AndreLanches.Models
{
    public class CarrinhoCompraItemModel
    {
        [Key]
        public int CarrinhoCompraItemId { get; set; }
        public LancheModel Lanche { get; set; }
        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }

    }
}
