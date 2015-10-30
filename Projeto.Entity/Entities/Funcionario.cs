using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entity.Entities
{
    public class Funcionario : Usuario
    {
        public virtual DateTime DataCadastro { get; set; }

        #region Relacionamentos

        public virtual List<Chamado> Chamados { get; set; }

        #endregion
    }
}
