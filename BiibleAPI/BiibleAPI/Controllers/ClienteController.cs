using BiibleAPI.Models;
using BiibleAPI.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BiibleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Autenticacao AutenticacaoServico;

        public ClienteController(IHttpContextAccessor context)
        {
            AutenticacaoServico = new Autenticacao(context);
        }

        [HttpGet]
        [Route("listagem")]
        public List<ClienteModel> Listagem()
        {
            return new ClienteModel().Listagem();
        }

        [HttpGet]
        [Route("cliente/{id}")]
        public ClienteModel GetById(int id)
        {
            return new ClienteModel().RetornarCliente(id);
        }

        [HttpPost]
        [Route("save")]
        public ReturnAllServices Save([FromBody] ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                AutenticacaoServico.Autenticar();
                dados.Save();
                retorno.Result = true;
                retorno.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar salvar cliente: " + ex.Message;
            }
            return retorno;
        }

        [HttpPut]
        [Route("update/{id}")]
        public ReturnAllServices Update(int id, [FromBody] ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                AutenticacaoServico.Autenticar();
                dados.Id = id;
                dados.Update();
                retorno.Result = true;
                retorno.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar atualizar cliente: " + ex.Message;
            }
            return retorno;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ReturnAllServices Delete(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                AutenticacaoServico.Autenticar();
                new ClienteModel().Delete(id);
                retorno.Result = true;
                retorno.ErrorMessage = "Cliente excluído com sucesso!";
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.ErrorMessage = ex.Message;
            }
            return retorno;
        }
    }
}
