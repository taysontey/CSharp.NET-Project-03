using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entity.Entities
{
    public class Telefone
    {
        public virtual int IdTelefone { get; set; }
        public virtual string Numero { get; set; }
        public virtual Tipo Tipo { get; set; }

        #region Relacionamentos

        public virtual Cliente Cliente { get; set; }

        #endregion
    }

    public enum Tipo
    {
        Residencial,
        Comercial,
        Celular
    }
}
