using Model;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class EntityRepository<T>: IRepository<T> where T : class, IDomainObject, new()
    {
        /// <summary> Добавляет новую сущность в БД </summary>
        /// <param name="entity"> Объект сущности </param>
        public void Add(T entity) 
        {
            using (DBContext context = new DBContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        /// <summary> Обновляет информацию о сущетсвующем объекте в БД </summary>
        /// <param name="newObject"> Объект сущности с обновленными данными </param>
        public void Update(T newObject) 
        {
            using (DBContext context = new DBContext())
            {
                context.Entry(newObject).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary> Уничтожает объект в БД по ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        public void Delete(int id) 
        {
            using (DBContext context = new DBContext())
            {
                var entity = context.Set<T>().Find(id);

                if (entity != null)
                {
                    context.Set<T>().Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        /// <summary> Получает список всех объектов в БД </summary>
        /// <returns> Возвращает список всех объектов из БД </returns>
        public List<T> ReadAll() 
        {
            using (DBContext context = new DBContext())
            {
                return new List<T>(context.Set<T>());
            }
        }

        /// <summary> Получает конкретный объект из БД по ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        /// <returns> Возвращает объект с нужным ID </returns>
        public T ReadById(int id) 
        {
            using (DBContext context = new DBContext())
            {
                return context.Set<T>().Find(id);
            }
        }
    }
}
