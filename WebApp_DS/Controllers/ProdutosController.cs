using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_DS.Entidades;
using WebApp_DS.Models;
using Microsoft.AspNetCore.Hosting;

namespace WebApp_DS.Controllers
{
    public class ProdutosController : Controller
    {
        // É o que permite a ligação com o banco

        private Contexto db;
        private IWebHostEnvironment webHostEnvironment; 
        public ProdutosController(Contexto contexto, IWebHostEnvironment _web) {

            db = contexto;
            webHostEnvironment = _web;
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

        public IActionResult SalvarDados(Produtos dados, IFormFile Imagem)
        {
            if(Imagem.Length > 0)
            {
                string caminho = webHostEnvironment.WebRootPath + "\\upload\\";
                if(Directory.Exists(caminho)){
                    Directory.CreateDirectory(caminho);
                }

                using (var stream = System.IO.File.Create (caminho + Imagem.FileName))
                {
                    Imagem.CopyToAsync(stream);
                }
                dados.CaminhoImagem = Imagem.FileName; 
            }
            db.PRODUTOS.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Lista");
        }
    }
}
