using Biible.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Biible.Rest
{
    public class ClienteREST
    {
        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> retorno = new List<ClienteModel>();
            string json = WebAPI.RequestGET("buscartodos", string.Empty);
            retorno = JsonConvert.DeserializeObject<List<ClienteModel>>(json);
            return retorno;
        }

        public ClienteModel Carregar(int? id)
        {
            ClienteModel retorno = new ClienteModel();
            string json = WebAPI.RequestGET("buscarregistro", id.ToString());
            retorno = JsonConvert.DeserializeObject<ClienteModel>(json);
            return retorno;
        }

        public void Inserir(ClienteModel dados)
        {
            string jsonData = JsonConvert.SerializeObject(dados);
            if (dados.id == 0)
            {
                string json = WebAPI.RequestPOST("salvar", jsonData);
            }
            else
            {
                string json = WebAPI.RequestPUT("alterar/" + dados.id, jsonData);
            }
        }

        public void Excluir(int id)
        {
            string json = WebAPI.RequestDELETE("deletar", id.ToString());
        }
    }
}
