using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Areas.LoggedFuncionario.Models
{
    public class ChamadoModelEdicao
    {
        public int IdChamado { get; set; }
        public string Solucao { get; set; }
    }

    public class ChamadoModelResultado
    {
        public int IdChamado { get; set; }
        public string Situacao { get; set; }
        public string Assunto { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Cliente_Nome { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}