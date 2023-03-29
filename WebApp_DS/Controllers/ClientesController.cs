using Microsoft.AspNetCore.Mvc;

namespace WebApp_DS.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
    }
}
