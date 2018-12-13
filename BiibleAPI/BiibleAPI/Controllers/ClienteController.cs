using BiibleAPI.Models;
using BiibleAPI.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiibleAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize()]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private string _cnxBiible;

        public ClienteController(IConfiguration configuration)
        {
            _cnxBiible = configuration.GetConnectionString("cnxBiible");
        }

        [HttpGet]
        [Route("BuscarRegistro/{id}")]
        public async Task<IActionResult> BuscarRegistro(int id)
        {
            using (AppDb db = new AppDb(_cnxBiible))
            {
                ClienteModel result = await new ClienteModel(db).BuscarRegistro(id);
                if (result == null)
                {
                    return new NotFoundResult();
                }
                return new OkObjectResult(result);
            }
        }

        [HttpGet]
        [Route("BuscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            using (AppDb db = new AppDb(_cnxBiible))
            {
                List<ClienteModel> result = await new ClienteModel(db).BuscarTodos();
                return new OkObjectResult(result);
            }
        }

        [HttpPost]
        [Route("Salvar")]
        public async Task<IActionResult> Salvar([FromBody]ClienteModel body)
        {
            using (AppDb db = new AppDb(_cnxBiible))
            {
                body.Db = db;
                await body.Salvar();
                return new OkObjectResult(body);
            }
        }

        [HttpPut]
        [Route("Alterar/{id}")]
        public async Task<IActionResult> Alterar(int id, [FromBody]ClienteModel body)
        {
            using (AppDb db = new AppDb(_cnxBiible))
            {
                body.Db = db;
                body.id = id;
                if (await body.BuscarRegistro(id) == null)
                {
                    return new NotFoundResult();
                }
                await body.Alterar();
                return new OkObjectResult(body);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            using (AppDb db = new AppDb(_cnxBiible))
            {
                ClienteModel result = await new ClienteModel(db).BuscarRegistro(id);
                if (result == null)
                {
                    return new NotFoundResult();
                }
                await result.Deletar();
                return new OkResult();
            }
        }
    }
}
