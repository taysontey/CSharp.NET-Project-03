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
    public class ClienteDal : GenericDal<Cliente>
    {
        public Cliente Authenticate(string Login, string Senha)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                var query = from c
                            in s.Query<Cliente>()
                            where c.Login.Equals(Login) && c.Senha.Equals(Senha)
                            select c;

                return query.FirstOrDefault();
            }
        }

        public bool CheckPassword(string Senha)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                var query = from c
                            in s.Query<Cliente>()
                            where c.Senha.Equals(Senha)
                            select c;

                return query.Count() > 0;
            }
        }

        public void UpdatePassword(Cliente c)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                ITransaction t = s.BeginTransaction();

                var query = from cli
                            in s.Query<Cliente>()
                            where cli.IdUsuario.Equals(c.IdUsuario)
                            select cli;

                foreach (Cliente cliente in query)
                {
                    cliente.Senha = c.Senha;
                    s.Update(cliente);
                }

                t.Commit();
            }
        }

        public bool HasLogin(string Login)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                var query = from c
                            in s.Query<Cliente>()
                            where c.Login.Equals(Login)
                            select c;

                return query.Count() > 0;
            }
        }

        public void AddCliente(Cliente c)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                ITransaction t = s.BeginTransaction();

                s.SaveOrUpdate(c);
                t.Commit();
            }
        }
    }
}
