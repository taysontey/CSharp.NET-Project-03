using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto.Entity.Entities;

namespace Projeto.DAL.Mapping
{
    public class TelefoneMap : ClassMap<Telefone>
    {
        public TelefoneMap()
        {
            Table("TELEFONE");

            Id(t => t.IdTelefone, "CODTELEFONE")
                .GeneratedBy.Identity();

            Map(t => t.Numero, "NUMERO")
                .Length(15)
                .Not.Nullable();

            Map(t => t.Tipo, "TIPO")
                .Length(12)
                .Not.Nullable();

            #region Relacionamentos

            References(t => t.Cliente)
                .Column("CODCLIENTE")
                .Cascade.All();

            #endregion
        }
    }
}
