using System.Data.Entity;
using Model;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=DefaultConnection"){}

        public DbSet<DrugBuyer> DrugBuyers { get; set; }
    }
}
