using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entity.Entities
{
    public class Endereco
    {
        public virtual int IdEndereco { get; set; }
        public virtual string Logradouro { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string CEP { get; set; }

        #region Relacionamentos

        public virtual Cliente Cliente { get; set; }
        
        #endregion
    }
}
