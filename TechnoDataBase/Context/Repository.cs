using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechnoDataBase.Interface;
using TechnoEntity.Entities;

namespace TechnoDataBase.Context
{
    public class Repository<T> : IRepository<T> where T : BaseParent
    {
        private readonly ContextDB _context;

        public Repository()
        {
            _context = new ContextDB();
        }

        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(Guid id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return _context.SaveChanges();
            }
            else
            {
                return -1;
            }
        }

        public List<T> DeleteAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> Find(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where).ToList();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public int Update(T entity, Guid id)
        {
            var existingEntity = _context.Set<T>().Find(id);

            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                return _context.SaveChanges();
            }
            else
            {
                return -1;
            }
        }

    }
}

