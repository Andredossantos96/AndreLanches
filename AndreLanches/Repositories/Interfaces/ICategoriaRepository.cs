using AndreLanches.Models;

namespace AndreLanches.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<CategoriaModel> Categorias { get; }
    }
}
