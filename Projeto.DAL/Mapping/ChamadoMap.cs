﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto.Entity.Entities;

namespace Projeto.DAL.Mapping
{
    public class ChamadoMap : ClassMap<Chamado>
    {
        public ChamadoMap()
        {
            Table("CHAMADO");

            Id(c => c.IdChamado, "CODCHAMADO")
                .GeneratedBy.Identity();

            Map(c => c.DataAbertura, "DATAABERTURA")
                .CustomType("date")
                .Not.Nullable();

            Map(c => c.DataFechamento, "DATAFECHAMENTO")
                .CustomType("date")
                .Not.Nullable();

            Map(c => c.Tipo, "TIPO")
                .Length(40)
                .Not.Nullable();

            Map(c => c.Descricao, "DESCRICAO")
                .Length(200)
                .Not.Nullable();

            Map(c => c.Situacao, "SITUACAO")
                .CustomType(typeof(Situacao))
                .Not.Nullable();

            Map(c => c.Solucao, "SOLUCAO")
                .Length(200)
                .Not.Nullable();

            #region Relacionamentos

            References(c => c.Cliente)
                .Column("CODCLIENTE")
                .Not.Nullable();

            References(c => c.Funcionario)
                .Column("CODFUNCIONARIO")
                .Not.Nullable();

            #endregion
        }
    }
}