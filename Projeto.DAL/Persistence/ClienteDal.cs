﻿using System;
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
    }
}
