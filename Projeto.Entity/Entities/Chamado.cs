using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entity.Entities
{
    public class Chamado
    {
        public virtual int IdChamado { get; set; }
        public virtual DateTime DataAbertura { get; set; }
        public virtual DateTime DataFechamento { get; set; }
        public virtual string Assunto { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Situacao Situacao { get; set; }
        public virtual string Solucao { get; set; }

        #region Relacionamentos

        public virtual Cliente Cliente { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        #endregion
    }

    public enum Situacao
    {
        Aberto,
        Fechado
    }
}
