using BiibleWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BiibleWEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ClienteModel objCliente = new ClienteModel();
            ViewBag.ListaClientes = objCliente.ListarTodosClientes();

            return View();
        }

        [HttpGet]
        public IActionResult Registrar(int? id)
        {
            if (id != null)
            {
                ViewBag.Registro = new ClienteModel().Carregar(id);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Registrar(ClienteModel dados)
        {
            dados.Inserir();
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["ClienteID"] = id.ToString();
            return View();
        }

        public IActionResult ExcluirCliente(int id)
        {
            new ClienteModel().Excluir(id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
