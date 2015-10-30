using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL.Generics
{
    interface IGenericDal<TEntity>
        where TEntity : class
    {
        void SaveOrUpdate(TEntity obj);
        void Delete(TEntity obj);
        List<TEntity> FindAll();
        TEntity FindById(int Id);
    }
}
