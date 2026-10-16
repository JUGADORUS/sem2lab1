using System.Collections.Generic;
using Model;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary> Добавляет новую сущность </summary>
        /// <param name="entity"> Объект сущности </param>
        void Add(T entity);

        /// <summary> Уничтожает объект по ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        void Delete(int id);

        /// <summary> Получает список всех объектов </summary>
        /// <returns> Возвращает список всех объектов </returns>
        List<T> ReadAll();

        /// <summary> Получает конкретный объект по ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        /// <returns> Возвращает объект с нужным ID </returns>
        T ReadById(int id);

        /// <summary> Обновляет информацию о сущетсвующем объекте </summary>
        /// <param name="newObject"> Объект сущности с обновленными данными </param>
        void Update(T newObject);
    }
}
