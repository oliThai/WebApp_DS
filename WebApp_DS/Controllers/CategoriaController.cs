using Microsoft.AspNetCore.Mvc;
using WebApp_DS.Entidades;
using WebApp_DS.Models;

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

        public IActionResult SalvarDados(CategoriaViewModel dados) {

            Categoria entidade = new Categoria();
            entidade.NOME = dados.Nome;
            entidade.ID = dados.Id;
            entidade.ATIVO = dados.Ativo;

            if(entidade.ID > 0) { 
                db.CATEGORIAS.Update(entidade);
                db.SaveChanges();
            }
            else
            {
                db.CATEGORIAS.Add(entidade);
                db.SaveChanges();
            }
            
            return RedirectToAction("Lista"); 
        }

        public ActionResult Excluir(int id) {
            Categoria item = db.CATEGORIAS.Find(id);
            if(item != null) {
                db.CATEGORIAS.Remove(item); 
                db.SaveChanges(); 
            }

            return RedirectToAction("Lista");
        }

        public IActionResult Editar(int id)
        {
            Categoria item = db.CATEGORIAS.Find(id);
            if(item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Lista");
            }
        }

    }
}
