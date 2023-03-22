using Microsoft.AspNetCore.Mvc;

namespace WebApp_DS.Views.Shared
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
