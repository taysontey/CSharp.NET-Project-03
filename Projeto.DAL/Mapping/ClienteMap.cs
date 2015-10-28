using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto.Entity.Entities;

namespace Projeto.DAL.Mapping
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("CLIENTE");

            Id(c => c.IdUsuario, "CODCLIENTE")
                .GeneratedBy.Identity();

            Map(c => c.Nome, "NOME")
                .Length(25)
                .Not.Nullable();

            Map(c => c.Sobrenome, "SOBRENOME")
                .Length(25)
                .Not.Nullable();

            Map(c => c.Login, "LOGIN")
                .Unique()
                .Length(50)
                .Not.Nullable();

            Map(c => c.Senha, "SENHA")
                .Length(50)
                .Not.Nullable();

            Map(c => c.DataNascimento, "DATANASCIMENTO")
                .CustomType("date")
                .Not.Nullable();

            Map(c => c.Sexo, "SEXO")
                .Length(10)
                .Not.Nullable();

            #region Relacionamentos

            References(c => c.Endereco)
                .Cascade.All()
                .Column("CODENDERECO");

            HasMany(c => c.Telefones)
                .KeyColumn("CODCLIENTE")
                .Inverse()
                .Cascade.All();

            HasMany(c => c.Chamados)
                .KeyColumn("CODCLIENTE")
                .Inverse();

            #endregion
        }
    }
}
