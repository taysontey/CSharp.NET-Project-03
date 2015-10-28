using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models.Cliente
{
    public class ClienteModelCadastro
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Numero1 { get; set; }
        public string Tipo1 { get; set; }
        public string Numero2 { get; set; }
        public string Tipo2 { get; set; }
  
    }

          
}