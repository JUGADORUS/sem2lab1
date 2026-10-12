using System.Collections.Generic;
using System.Data;
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
        IDbConnection db = new SqlConnection(connectionString);


        public void Add(T entity)
        {
            string sqlQuery = "INSERT INTO DrugBuyers (Name, District, FavouriteDrug) " +
                              "VALUES (@Name, @District, @FavouriteDrug); " +
                              "SELECT CAST(SCOPE_IDENTITY() as int)";

            int newId = db.Query<int>(sqlQuery, entity).FirstOrDefault();
            entity.Id = newId;
        }


        public void Delete(int id)
        {
            string sqlQuery = "DELETE FROM DrugBuyers WHERE Id = @Id";

            db.Execute(sqlQuery, new { Id = id });
        }


        public List<T> ReadAll()
        {
            return db.Query<T>("SELECT * FROM DrugBuyers").ToList();
        }

        public T ReadById(int id)
        {
            string sqlQuery = "SELECT * FROM DrugBuyers WHERE Id = @Id";

            return db.Query<T>(sqlQuery, new { Id = id }).FirstOrDefault();
        }

        public void Update(T entity)
        {
            string sqlQuery = "UPDATE DrugBuyers SET Name = @Name, District = @District, FavouriteDrug = @FavouriteDrug WHERE Id = @Id";

            db.Execute(sqlQuery, entity);
        }
    }
}
