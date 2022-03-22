namespace AndreLanches.Models
{
    public class CategoriaModel
    {
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }
        public List<LancheModel> Lanches { get; set; }


    }
}
