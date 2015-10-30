using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Projeto.DAL.Util;

namespace Projeto.DAL.Generics
{
    public class GenericDal<TEntity> : IGenericDal<TEntity>
        where TEntity : class
    {

        public void SaveOrUpdate(TEntity obj)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.SaveOrUpdate(obj);
                t.Commit();
            }
        }

        public void Delete(TEntity obj)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Delete(obj);
                t.Commit();
            }
        }

        public void DeleteById(object id)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            using (ITransaction t = s.BeginTransaction())
            {
                var queryString = string.Format("delete {0} where id = :id", typeof(TEntity));
                s.CreateQuery(queryString)
                       .SetParameter("id", id)
                       .ExecuteUpdate();

                t.Commit();
            }
        }

        public List<TEntity> FindAll()
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                var query = from obj
                            in s.Query<TEntity>()
                            select obj;

                return query.ToList();
            }
        }

        public TEntity FindById(int Id)
        {
            using (ISession s = HibernateUtil.Factory.OpenSession())
            {
                return (TEntity)s.Get(typeof(TEntity), Id);
            }
        }
    }
}
