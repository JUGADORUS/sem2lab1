using Model;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class EntityRepository<T>: IRepository<T> where T : class, IDomainObject, new()
    {
        private readonly DBContext _context;
        public EntityRepository(DBContext context)
        {
            _context = context;
        }

        public void Add(T entity) 
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T newObject) 
        {
            _context.Entry(newObject).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }
        public void Delete(int id) 
        {
            var entity = _context.Set<T>().Find(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }
        public List<T> ReadAll() 
        {
            return new List<T>(_context.Set<T>());
        }
        public T ReadById(int id) 
        {
            return _context.Set<T>().Find(id);
        }

    }
}
