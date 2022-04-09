using AndreLanches.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AndreLanches.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoryRepository;

        public CategoriaMenu(ICategoriaRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categoria = _categoryRepository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categoria);
        }
    }
}
