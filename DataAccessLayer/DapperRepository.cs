using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Model;
using Dapper;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject, new() 
    {
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:" +
            "\\Users\\User\\source\\repos\\sem2lab1\\DataAccessLayer\\Database1.mdf;Integrated " +
            "Security=True";

        /// <summary> Добавляет новую сущность в БД </summary>
        /// <param name="entity"> Объект сущности </param>
        public void Add(T entity)
        {
            string sqlQuery = "INSERT INTO DrugBuyers (Name, District, FavouriteDrug) " +
                              "VALUES (@Name, @District, @FavouriteDrug); " +
                              "SELECT CAST(SCOPE_IDENTITY() as int)";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                int newId = db.Query<int>(sqlQuery, entity).FirstOrDefault();
                entity.Id = newId;
            }
        }

        /// <summary> Уничтожает объект в БД по ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        public void Delete(int id)
        {
            string sqlQuery = "DELETE FROM DrugBuyers WHERE Id = @Id";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Execute(sqlQuery, new { Id = id });
            }
        }

        /// <summary> Получает список всех объектов в БД </summary>
        /// <returns> Возвращает список всех объектов из БД </returns>
        public List<T> ReadAll()
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>("SELECT * FROM DrugBuyers").ToList();
            }
        }

        /// <summary> Получает конкретный объект из БД по ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        /// <returns> Возвращает объект с нужным ID </returns>
        public T ReadById(int id)
        {
            string sqlQuery = "SELECT * FROM DrugBuyers WHERE Id = @Id";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                return db.Query<T>(sqlQuery, new { Id = id }).FirstOrDefault();
            }
        }

        /// <summary> Обновляет информацию о сущетсвующем объекте в БД </summary>
        /// <param name="newObject"> Объект сущности с обновленными данными </param>
        public void Update(T entity)
        {
            string sqlQuery = "UPDATE DrugBuyers SET Name = @Name, District = @District, FavouriteDrug = @FavouriteDrug WHERE Id = @Id";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Execute(sqlQuery, entity);
            }
        }
    }
}
