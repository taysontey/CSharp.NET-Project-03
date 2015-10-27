using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Web.Models.Endereco;
using Projeto.Web.Models.Telefone;

namespace Projeto.Web.Models.Cliente
{
    public class ClienteModelCadastro
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }

        #region Relacionamentos

        public EnderecoModelCadastro Endereco { get; set; }
        public ICollection<TelefoneModelCadastro> Telefones { get; set; }

        #endregion
    }

    public enum Sexo
    {
        Masculino,
        Feminino
    }        
}