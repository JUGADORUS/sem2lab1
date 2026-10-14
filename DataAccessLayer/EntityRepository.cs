using Model;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public class EntityRepository<T>: IRepository<T> where T : class, IDomainObject, new()
    {
        private readonly DBContext _context;

        /// <summary> Создает новый экземпляр репозитория </summary>
        /// <param name="context"> Контекст БД EF, используется для доступа к данным </param>
        public EntityRepository(DBContext context)
        {
            _context = context;
        }

        /// <summary> Добавляет новую сущность в БД </summary>
        /// <param name="entity"> Объект сущности </param>
        public void Add(T entity) 
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary> Обновляет информацию о сущетсвующем объекте в БД </summary>
        /// <param name="newObject"> Объект сущности с обновленными данными </param>
        public void Update(T newObject) 
        {
            _context.Entry(newObject).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        /// <summary> Уничтожает объект в БД по номеру ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        public void Delete(int id) 
        {
            var entity = _context.Set<T>().Find(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        /// <summary> Получает список всех объектов в БД </summary>
        /// <returns> Возвращает список покупателей всех покупателей из БД </returns>
        public List<T> ReadAll() 
        {
            return new List<T>(_context.Set<T>());
        }

        /// <summary> Получает конкретного покупателя из БД по ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        /// <returns> Возвращает покупателя с нужным ID </returns>
        public T ReadById(int id) 
        {
            return _context.Set<T>().Find(id);
        }

    }
}
