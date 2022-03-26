using AndreLanches.Models;

namespace AndreLanches.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<LancheModel> Lanches { get; }
        IEnumerable<LancheModel> LanchesPreferidos { get; }
        LancheModel GetLancheById(int lancheId);
    }
}
