using Microsoft.AspNetCore.Mvc;

namespace AndreLanches.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Contato()
        {
            return View();
        }
    }
}
