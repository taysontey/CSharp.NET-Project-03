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
    public class FuncionarioDal : GenericDal<Funcionario>
    {
        public Funcionario Authenticate(string Login, string Senha)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                var query = from f
                            in s.Query<Funcionario>()
                            where f.Login.Equals(Login) && f.Senha.Equals(Senha)
                            select f;

                return query.FirstOrDefault();
            }
        }

        public bool HasLogin(string Login)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                var query = from f
                            in s.Query<Funcionario>()
                            where f.Login.Equals(Login)
                            select f.Login;

                return query.Count() > 0;
            }
        }
    }
}
