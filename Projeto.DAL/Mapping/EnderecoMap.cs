using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto.Entity.Entities;

namespace Projeto.DAL.Mapping
{
    public class EnderecoMap : ClassMap<Endereco>
    {
        public EnderecoMap()
        {
            Table("ENDERECO");

            Id(e => e.IdEndereco, "CODENDERECO")
                .GeneratedBy.Identity();

            Map(e => e.Logradouro, "LOGRADOURO")
                .Length(50)
                .Not.Nullable();

            Map(e => e.Bairro, "BAIRRO")
                .Length(50)
                .Not.Nullable();

            Map(e => e.Cidade, "CIDADE")
                .Length(50)
                .Not.Nullable();

            Map(e => e.Estado, "ESTADO")
                .Length(2)
                .Not.Nullable();

            Map(e => e.CEP, "CEP")
                .Length(10)
                .Not.Nullable();

            #region Relacionamentos

            References(e => e.Cliente)
                .Column("CODCLIENTE")
                .Unique()
                .Cascade.All();

            #endregion
        }
    }
}
