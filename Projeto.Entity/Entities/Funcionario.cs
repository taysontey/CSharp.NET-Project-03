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

        public virtual ICollection<Chamado> Chamados { get; set; }

        #endregion
    }
}
