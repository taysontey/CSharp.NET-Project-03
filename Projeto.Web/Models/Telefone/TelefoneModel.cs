using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Models.Telefone
{
    public class TelefoneModelCadastro
    {
        public string Numero { get; set; }
        public Tipo Tipo { get; set; }
    }

    public enum Tipo
    {
        Residencial,
        Comercial,
        Celular
    }
}