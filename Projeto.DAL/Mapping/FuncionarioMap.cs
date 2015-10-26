using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto.Entity.Entities;

namespace Projeto.DAL.Mapping
{
    public class FuncionarioMap : ClassMap<Funcionario>
    {
        public FuncionarioMap()
        {
            Table("FUNCIONARIO");

            Id(f => f.IdUsuario, "CODFUNCIONARIO")
                .GeneratedBy.Identity();

            Map(f => f.Nome, "NOME")
                .Length(25)
                .Not.Nullable();

            Map(f => f.Sobrenome, "SOBRENOME")
                .Length(25)
                .Not.Nullable();

            Map(f => f.Login, "LOGIN")
                .Unique()
                .Length(50)
                .Not.Nullable();

            Map(f => f.Senha, "SENHA")
                .Length(50)
                .Not.Nullable();

            Map(f => f.DataCadastro, "DATACADASTRO")
                .CustomType("date")
                .Not.Nullable();

            #region Relacionamentos

            HasMany(f => f.Chamados)
                .KeyColumn("CODFUNCIONARIO")
                .Inverse();

            #endregion
        }
    }
}
