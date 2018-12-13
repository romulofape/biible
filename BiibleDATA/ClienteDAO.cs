using Biible.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Biible.Data
{
    public class ClienteDAO
    {
        [JsonIgnore]
        public AppDb _Db { get; set; }

        public ClienteDAO(AppDb db = null)
        {
            _Db = db;
            if (db != null)
            {
                _Db.AbriConexao();
            }
        }

        public async Task<List<ClienteModel>> BuscarTodos()
        {
            string sql = @"select * from cliente order by nome asc";

            return await RetornoBuscar(await _Db.ExecutarSQL(sql));
        }

        public async Task<ClienteModel> BuscarRegistro(int id)
        {
            string sql = $"select * from cliente where id = {id}";

            List<ClienteModel> result = await RetornoBuscar(await _Db.ExecutarSQL(sql));
            return result.Count > 0 ? result[0] : null;
        }

        public async Task Salvar(ClienteModel obj)
        {
            string sql = "INSERT INTO cliente(nome, data_cadastro, cpf_cnpj, data_nascimento, " +
                             "telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf) " +
                            $"VALUES('{obj.nome}', " +
                            $"'{obj.data_cadastro.ToString("yyyy-MM-dd")}'," +
                            $"'{obj.cpf_cnpj}'," +
                            $"'{obj.data_nascimento.ToString("yyyy-MM-dd")}'," +
                            $"'{obj.telefone}','{obj.email}'," +
                            $"'{obj.cep}','{obj.logradouro}'," +
                            $"'{obj.numero}'," +
                            $"'{obj.bairro}'," +
                            $"'{obj.complemento}'," +
                            $"'{obj.cidade}'," +
                            $"'{obj.uf}')";

            obj.id = await _Db.ExecutarComando(sql);
        }

        public async Task Alterar(ClienteModel obj)
        {
            string sql = "UPDATE cliente set " +
                         $" nome = '{obj.nome}', " +
                         $" data_cadastro = '{obj.data_cadastro.ToString("yyyy-MM-dd")}', " +
                         $" cpf_cnpj = '{obj.cpf_cnpj}', " +
                         $" data_nascimento = '{obj.data_nascimento.ToString("yyyy-MM-dd")}', " +
                         $" telefone = '{obj.telefone}', " +
                         $" email = '{obj.email}',  " +
                         $" cep = '{obj.cep}',  " +
                         $" logradouro = '{obj.logradouro}'," +
                         $" numero = '{obj.numero}', " +
                         $" bairro = '{obj.bairro}', " +
                         $" complemento= '{obj.complemento}', " +
                         $" cidade= '{obj.cidade}', " +
                         $" uf = '{obj.uf}' " +
                         $"WHERE id={obj.id}";

            await _Db.ExecutarComando(sql);
        }

        public async Task Deletar(int id)
        {
            string sql = $"delete from cliente where id = {id}";
            await _Db.ExecutarComando(sql);
        }

        private async Task<List<ClienteModel>> RetornoBuscar(DbDataReader reader)
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    ClienteModel registro = new ClienteModel
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
