﻿using Dapper.Contrib.Extensions;
using System;

namespace Biible.Models
{
    [Table("cliente")]
    public class ClienteModel
    {
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
    }
}
