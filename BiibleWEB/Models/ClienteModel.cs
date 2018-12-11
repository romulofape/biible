using BiibleWEB.Util;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BiibleWEB.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_Cadastro { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Data_Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public List<ClienteModel> ListarTodosClientes()
        {
            List<ClienteModel> retorno = new List<ClienteModel>();
            string json = WebAPI.RequestGET("listagem", string.Empty);
            retorno = JsonConvert.DeserializeObject<List<ClienteModel>>(json);
            return retorno;
        }

        public ClienteModel Carregar(int? id)
        {
            ClienteModel retorno = new ClienteModel();
            string json = WebAPI.RequestGET("cliente", id.ToString());
            retorno = JsonConvert.DeserializeObject<ClienteModel>(json);
            return retorno;
        }

        public void Inserir()
        {
            string jsonData = JsonConvert.SerializeObject(this);
            if (Id == 0)
            {
                string json = WebAPI.RequestPOST("save", jsonData);
            }
            else
            {
                string json = WebAPI.RequestPUT("update/" + Id, jsonData);
            }
        }

        public void Excluir(int id)
        {
            string json = WebAPI.RequestDELETE("delete", id.ToString());
        }
    }
}
