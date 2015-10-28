using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entity.Entities
{
    public class Cliente : Usuario
    {
        public virtual DateTime DataNascimento { get; set; }
        public virtual Sexo Sexo { get; set; }

        #region Relacionamentos

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; }

        #endregion       
    }

    public enum Sexo
    {
        Masculino,
        Feminino
    }
}
