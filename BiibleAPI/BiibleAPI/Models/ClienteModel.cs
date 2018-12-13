using BiibleAPI.Util;
using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace BiibleAPI.Models
{
    [Table("cliente")]
    public class ClienteModel
    {
        [JsonIgnore]
        public AppDb Db { get; set; }

        public ClienteModel(AppDb db = null)
        {
            Db = db;
            if (db != null)
            {
                Db.AbriConexao();
            }
        }

        [ExplicitKey]
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime data_cadastro { get; set; }
        public string cpf_cnpj { get; set; }
        public DateTime data_nascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }

        public async Task<List<ClienteModel>> BuscarTodos()
        {
            string sql = @"select * from cliente order by nome asc";

            return await RetornoBuscar(await Db.ExecutarSQL(sql));
        }

        public async Task<ClienteModel> BuscarRegistro(int id)
        {
            string sql = $"select * from cliente where id = {id}";

            List<ClienteModel> result = await RetornoBuscar(await Db.ExecutarSQL(sql));
            return result.Count > 0 ? result[0] : null;
        }

        public async Task Salvar()
        {
            string sql = "INSERT INTO cliente(nome, data_cadastro, cpf_cnpj, data_nascimento, " +
                             "telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf) " +
                            $"VALUES('{nome}', " +
                            $"'{data_cadastro.ToString("yyyy-MM-dd")}'," +
                            $"'{cpf_cnpj}'," +
                            $"'{data_nascimento.ToString("yyyy-MM-dd")}'," +
                            $"'{telefone}','{email}'," +
                            $"'{cep}','{logradouro}'," +
                            $"'{numero}'," +
                            $"'{bairro}'," +
                            $"'{complemento}'," +
                            $"'{cidade}'," +
                            $"'{uf}')";

            id = await Db.ExecutarComando(sql);
        }

        public async Task Alterar()
        {
            string sql = "UPDATE cliente set " +
                         $" nome = '{nome}', " +
                         $" data_cadastro = '{data_cadastro.ToString("yyyy-MM-dd")}', " +
                         $" cpf_cnpj = '{cpf_cnpj}', " +
                         $" data_nascimento = '{data_nascimento.ToString("yyyy-MM-dd")}', " +
                         $" telefone = '{telefone}', " +
                         $" email = '{email}',  " +
                         $" cep = '{cep}',  " +
                         $" logradouro = '{logradouro}'," +
                         $" numero = '{numero}', " +
                         $" bairro = '{bairro}', " +
                         $" complemento= '{complemento}', " +
                         $" cidade= '{cidade}', " +
                         $" uf = '{uf}' " +
                         $"WHERE id={id}";

            await Db.ExecutarComando(sql);
        }

        public async Task Deletar()
        {
            string sql = $"delete from cliente where id = {id}";
            await Db.ExecutarComando(sql);
        }

        private async Task<List<ClienteModel>> RetornoBuscar(DbDataReader reader)
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    ClienteModel registro = new ClienteModel(Db)
                    {
                        id = await reader.GetFieldValueAsync<int>(reader.GetOrdinal("id")),
                        nome = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("nome")),
                        data_cadastro = await reader.GetFieldValueAsync<DateTime>(reader.GetOrdinal("data_cadastro")),
                        cpf_cnpj = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("cpf_cnpj")),
                        data_nascimento = await reader.GetFieldValueAsync<DateTime>(reader.GetOrdinal("data_nascimento")),
                        telefone = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("telefone")),
                        email = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("email")),
                        cep = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("cep")),
                        logradouro = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("logradouro")),
                        numero = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("numero")),
                        bairro = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("bairro")),
                        complemento = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("complemento")),
                        cidade = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("cidade")),
                        uf = await reader.GetFieldValueAsync<string>(reader.GetOrdinal("uf"))
                    };
                    lista.Add(registro);
                }
            }
            return lista;
        }
    }
}
