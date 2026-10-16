using Dapper;
using Model;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<DrugBuyer>
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        /// <summary> Добавляет новую сущность в БД </summary>
        /// <param name="entity"> Объект сущности </param>
        public void Add(DrugBuyer entity)
        {
            string sqlQuery = "INSERT INTO DrugBuyers (Name, District, FavouriteDrug) " +
                              "VALUES (@Name, @District, @FavouriteDrug); " +
                              "SELECT CAST(SCOPE_IDENTITY() as int)";

            using (SqlConnection db = new SqlConnection(_connectionString))
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

            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sqlQuery, new { Id = id });
            }
        }

        /// <summary> Получает список всех объектов в БД </summary>
        /// <returns> Возвращает список всех объектов из БД </returns>
        public List<DrugBuyer> ReadAll()
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<DrugBuyer>("SELECT * FROM DrugBuyers").ToList();
            }
        }

        /// <summary> Получает конкретный объект из БД по ID </summary>
        /// <param name="id"> Уникальный идентификатор объекта </param>
        /// <returns> Возвращает объект с нужным ID </returns>
        public DrugBuyer ReadById(int id)
        {
            string sqlQuery = "SELECT * FROM DrugBuyers WHERE Id = @Id";

            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<DrugBuyer>(sqlQuery, new { Id = id }).FirstOrDefault();
            }
        }

        /// <summary> Обновляет информацию о сущетсвующем объекте в БД </summary>
        /// <param name="newObject"> Объект сущности с обновленными данными </param>
        public void Update(DrugBuyer entity)
        {
            string sqlQuery = "UPDATE DrugBuyers SET Name = @Name, District = @District, FavouriteDrug = @FavouriteDrug WHERE Id = @Id";

            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(sqlQuery, entity);
            }
        }
    }
}
