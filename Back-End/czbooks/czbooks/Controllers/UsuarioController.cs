using Microsoft.AspNetCore.Mvc;

namespace czbooks.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
