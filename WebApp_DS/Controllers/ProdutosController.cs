using Microsoft.AspNetCore.Mvc;

namespace WebApp_DS.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
