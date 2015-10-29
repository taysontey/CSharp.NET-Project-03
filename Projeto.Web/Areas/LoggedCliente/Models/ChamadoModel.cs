using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entity.Entities;

namespace Projeto.Web.Areas.LoggedCliente.Models
{
    public class ChamadoModelCadastro
    {
        public DateTime DataAbertura { get; set; }
        public string Assunto { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }

        #region Relacionamentos

        public Cliente Cliente { get; set; }

        #endregion
    }
}