using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using System.Data.Common;

namespace DataAccessLayer
{
    public class DBContext: DbContext
    {   
        public DBContext() : base("name=DefaultConnection") { }
        public DbSet<DrugBuyer> DrugBuyers { get; set; }

    }
}
