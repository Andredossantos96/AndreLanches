using AndreLanches.Models;

namespace AndreLanches.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<LancheModel> Lanches { get; set; }
        public string CategoriaAtual { get; set; }  
    }
}
