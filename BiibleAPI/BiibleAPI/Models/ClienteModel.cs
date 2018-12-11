using BiibleAPI.Util;
using System;
using System.Collections.Generic;
using System.Data;

namespace BiibleAPI.Models
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


        public void Save()
        {
            DAL objDAL = new DAL();

            string sql = "INSERT INTO cliente(nome,data_cadastro,cpf_cnpj,data_nascimento,telefone,email,cep,logradouro,numero,bairro,complemento,cidade,uf)" +
                        $"VALUES('{Nome}',{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")},'{Cpf_Cnpj}',{DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd")},'{Telefone}','{Email}','{Cep}','{Logradouro}','{Numero}','{Bairro}','{Complemento}','{Cidade}','{UF}')";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void Update()
        {
            DAL objDAL = new DAL();

            string sql = "UPDATE cliente set " +
                         $" nome = '{Nome}', " +
                         $" data_cadastro = '{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}', " +
                         $" cpf_cnpj = '{Cpf_Cnpj}', " +
                         $" data_nascimento = '{DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd")}', " +
                         $" telefone = '{Telefone}', " +
                         $" email = '{Email}',  " +
                         $" cep = '{Cep}',  " +
                         $" logradouro = '{Logradouro}'," +
                         $" numero = '{Numero}', " +
                         $" bairro = '{Bairro}', " +
                         $" complemento= '{Complemento}', " +
                         $" cidade= '{Cidade}', " +
                         $" uf = '{UF}' " +
                         $"WHERE id={Id}";

            objDAL.ExecutarComandoSQL(sql);
        }

        public void Delete(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"delete from cliente where id = {id}";

            objDAL.ExecutarComandoSQL(sql);
        }

        public List<ClienteModel> Listagem()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;

            DAL objDAL = new DAL();

            string sql = "select * from cliente order by nome asc";
            DataTable dados = objDAL.RetornarDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new ClienteModel()
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Nome = dados.Rows[i]["Nome"].ToString(),
                    Data_Cadastro = DateTime.Parse(dados.Rows[i]["data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                    Cpf_Cnpj = dados.Rows[i]["cpf_cnpj"].ToString(),
                    Data_Nascimento = DateTime.Parse(dados.Rows[i]["data_nascimento"].ToString()).ToString("dd/MM/yyyy"),
                    Telefone = dados.Rows[i]["telefone"].ToString(),
                    Email = dados.Rows[i]["email"].ToString(),
                    Cep = dados.Rows[i]["cep"].ToString(),
                    Logradouro = dados.Rows[i]["logradouro"].ToString(),
                    Numero = dados.Rows[i]["numero"].ToString(),
                    Bairro = dados.Rows[i]["bairro"].ToString(),
                    Cidade = dados.Rows[i]["cidade"].ToString(),
                    UF = dados.Rows[i]["uf"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public ClienteModel RetornarCliente(int id)
        {
            ClienteModel item;

            DAL objDAL = new DAL();

            string sql = $"select * from cliente where id = {id}";
            DataTable dados = objDAL.RetornarDataTable(sql);

            item = new ClienteModel()
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Nome = dados.Rows[0]["Nome"].ToString(),
                Data_Cadastro = DateTime.Parse(dados.Rows[0]["data_cadastro"].ToString()).ToString("dd/MM/yyyy"),
                Cpf_Cnpj = dados.Rows[0]["cpf_cnpj"].ToString(),
                Data_Nascimento = DateTime.Parse(dados.Rows[0]["data_nascimento"].ToString()).ToString("dd/MM/yyyy"),
                Telefone = dados.Rows[0]["telefone"].ToString(),
                Email = dados.Rows[0]["email"].ToString(),
                Cep = dados.Rows[0]["cep"].ToString(),
                Logradouro = dados.Rows[0]["logradouro"].ToString(),
                Complemento = dados.Rows[0]["complemento"].ToString(),
                Numero = dados.Rows[0]["numero"].ToString(),
                Bairro = dados.Rows[0]["bairro"].ToString(),
                Cidade = dados.Rows[0]["cidade"].ToString(),
                UF = dados.Rows[0]["uf"].ToString()
            };

            return item;
        }
    }
}
