using Microsoft.AspNetCore.Mvc;
using WebApp_DS.Entidades;

namespace WebApp_DS.Controllers
{
    public class CategoriaController : Controller
    {
        private Contexto db;
        public CategoriaController(Contexto db)
        {
            this.db = db;
        }
        public IActionResult Lista()
        {
            return View(db.CATEGORIAS.ToList());
        }

        public IActionResult Cadastro() 
        {
            return View();
        }

        [HttpPost]

        public IActionResult SalvarDados(Categoria dados) {

            db.CATEGORIAS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Lista"); 
        }


    }
}
