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
        private IConfiguration _configuration;

        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("BuscarRegistro/{id}")]
        public async Task<IActionResult> BuscarRegistro(int id)
        {
            using (AppDb db = new AppDb(_configuration.GetConnectionString("cnxBiible")))
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
        [Route("buscartodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            using (AppDb db = new AppDb(_configuration.GetConnectionString("cnxBiible")))
            {
                List<ClienteModel> result = await new ClienteModel(db).BuscarTodos();
                return new OkObjectResult(result);
            }
        }

        [HttpPost]
        [Route("salvar")]
        public async Task<IActionResult> Salvar([FromBody]ClienteModel body)
        {
            using (AppDb db = new AppDb(_configuration.GetConnectionString("cnxBiible")))
            {
                body.Db = db;
                await body.Salvar();
                return new OkObjectResult(body);
            }
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public async Task<IActionResult> Alterar(int id, [FromBody]ClienteModel body)
        {
            using (AppDb db = new AppDb(_configuration.GetConnectionString("cnxBiible")))
            {
                ClienteModel result = await new ClienteModel(db).BuscarRegistro(id);
                if (result == null)
                {
                    return new NotFoundResult();
                }
                await result.Alterar();
                return new OkObjectResult(result);
            }
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            using (AppDb db = new AppDb(_configuration.GetConnectionString("cnxBiible")))
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
