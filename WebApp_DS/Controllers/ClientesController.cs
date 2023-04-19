using Microsoft.AspNetCore.Mvc;
using WebApp_DS.Models;

namespace WebApp_DS.Controllers
{
    public class ClientesController : Controller
    {
        public static List<ClienteViewModel> lista = new List<ClienteViewModel>();
        public IActionResult Lista()
        {

            //for (var i = 0; i < 16; i++)
            //{
            //    ClienteViewModel novo = new ClienteViewModel();
            //    novo.Nome = "Cliente" + i;
            //    novo.Id = 1 + i;
            //    novo.Telefone = "16997892986";
            //    Lista.Add(novo);
            //}
           
            return View(lista);

        }
        public IActionResult Cadastro() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult SalvarDados(ClienteViewModel model)
        {
            if (model.Id > 0) {
                int indice = lista.FindIndex(a => a.Id == model.Id);
                lista[indice] = model;
            }
            else
            {
                Random rand = new Random();
                model.Id = rand.Next(1,999);
                lista.Add(model);
            }
            
            return RedirectToAction("Lista");
        }

        [HttpPost]
        public IActionResult Cadastro(string Nome, string Telefone) 
        {
            if(string.IsNullOrEmpty(Nome))
            {
                TempData["Erro"] = "O campo nome não pode estar em branco";
            }
            if(string.IsNullOrEmpty(Telefone))
            {
                TempData["Erro"] = "O campo telefone não pode estar em branco";
            }
            return View();
        }
        public IActionResult Editar(int id) 
        {
            ClienteViewModel cliente = lista.Find(a => a.Id == id);
            if(cliente != null)
            {
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Lista");
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ClienteViewModel cliente = lista.Find(a => a.Id == id);
            if(cliente != null) 
            {
                lista.Remove(cliente);
            }
            return RedirectToAction("Lista");
        }
    }
}
