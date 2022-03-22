namespace AndreLanches.Models
{
    public class LancheModel
    {
        public int LancheId { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool Emestoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual CategoriaModel Categoria { get; set; }



    }
}
