using Microsoft.AspNetCore.Mvc;
using WebApp_DS.Entidades;

namespace WebApp_DS.Controllers
{
    public class ProdutosController : Controller
    {
        // É o que permite a ligação com o banco

        private Contexto db;
        public ProdutosController(Contexto contexto) {

            db = contexto;
        }
        public IActionResult Lista()
        {
            return View();
        }

        public IActionResult Cadastro() {
        
            return View();
        }
        [HttpPost]

        public IActionResult SalvarDados(Produtos dados) {
            db.PRODUTOS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Lista");
        }
    }
}
