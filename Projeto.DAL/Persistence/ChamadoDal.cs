using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entity.Entities;
using Projeto.DAL.Generics;
using Projeto.DAL.Util;
using NHibernate;
using NHibernate.Linq;

namespace Projeto.DAL.Persistence
{
    public class ChamadoDal : GenericDal<Chamado>
    {
        public List<Chamado> FindAllByCliente(Cliente c)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                var query = from ch
                            in s.Query<Chamado>()
                            where ch.Cliente == c
                            select new Chamado
                            {
                                IdChamado = ch.IdChamado,
                                Assunto = ch.Assunto,
                                Situacao = ch.Situacao,
                                DataAbertura = ch.DataAbertura,
                                Descricao = ch.Descricao
                            };

                return query.ToList();
            }
        }

        public Chamado FindById(int Id)
        {
            using(ISession s = HibernateUtil.Factory.OpenSession())
            {
                var query = from ch
                            in s.Query<Chamado>()
                            where ch.IdChamado.Equals(Id)
                            select new Chamado
                            {
                                IdChamado = ch.IdChamado,
                                Assunto = ch.Assunto,
                                Descricao = ch.Descricao
                            };
                return query.FirstOrDefault();
            }
        }

        public void Update(Chamado ch)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                ITransaction t = s.BeginTransaction();

                var query = s.CreateQuery("update Chamado set ASSUNTO=:val1, DESCRICAO=:val2 where CODCHAMADO=:val3");

                query.SetParameter("val1", ch.Assunto);
                query.SetParameter("val2", ch.Descricao);
                query.SetParameter("val3", ch.IdChamado);
                query.ExecuteUpdate();

                t.Commit();
            }
        }
    }
}
