using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechnoEntity.Entities;

namespace TechnoDataBase.Interface
{
    public interface IRepository<T> where T : BaseParent
    {
        T Get(int id);
        int Add(T entity);
        int Update(T entity, Guid id);
        int Delete(Guid id);
        List<T> GetAll();
        List<T> DeleteAll();
        List<T> Find(Expression<Func<T, bool>> where);
    }
}
