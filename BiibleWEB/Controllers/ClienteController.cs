using Biible.Models;
using Biible.Rest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BiibleWEB.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        // GET: Cliente
        public IActionResult Index()
        {
            ClienteREST objCliente = new ClienteREST();
            ViewBag.ListaClientes = objCliente.ListarTodosClientes();

            return View();
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ClienteModel cliModel = new ClienteREST().Carregar(id);
            if (cliModel == null)
            {
                return NotFound();
            }
            return View(cliModel);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<IActionResult> Create(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(clienteModel);
                //await _context.SaveChangesAsync();

                new ClienteREST().Inserir(clienteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ////var clienteModel = await _context.ClienteModel.SingleOrDefaultAsync(m => m.id == id);
            ////if (clienteModel == null)
            ////{
            ////    return NotFound();
            ////}
            //return View(clienteModel);
            return View();
        }

        // PUT: Cliente/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteModel clienteModel)
        {
            if (id != clienteModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ////_context.Update(clienteModel);
                    ////await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelExists(clienteModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //var clienteModel = await _context.ClienteModel
            //    .SingleOrDefaultAsync(m => m.id == id);
            //if (clienteModel == null)
            //{
            //    return NotFound();
            //}

            new ClienteREST().Excluir(id);

            //return View(clienteModel);
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var clienteModel = await _context.ClienteModel.SingleOrDefaultAsync(m => m.id == id);
            //_context.ClienteModel.Remove(clienteModel);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return View();
        }

        private bool ClienteModelExists(int id)
        {
            ///// return _context.ClienteModel.Any(e => e.id == id);
            return false;
        }
    }
}
