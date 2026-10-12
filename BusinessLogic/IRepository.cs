using System.Collections.Generic;

namespace Model
{
    public interface IRepository<T> where T : IDomainObject
    {
        void Add(T entity);
        void Delete(int id);
        List<T> ReadAll();
        T ReadById(int id);
        void Update(T newObject);
    }
}
