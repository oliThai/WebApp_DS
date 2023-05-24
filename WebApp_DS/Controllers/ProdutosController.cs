using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_DS.Entidades;
using WebApp_DS.Models;

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
            List<Produtos> model = new List<Produtos>();
            model = db.PRODUTOS.Include(a => a.CATEGORIA).ToList();
            return View(model);
        }

        public IActionResult Cadastro() {
            NovoProdutoViewModel model = new NovoProdutoViewModel();
            model.ListaCategorias = db.CATEGORIAS.ToList();
            return View(model);
        }
        [HttpPost]

        public IActionResult SalvarDados(Produtos dados)
        {
            db.PRODUTOS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Lista");
        }
    }
}
