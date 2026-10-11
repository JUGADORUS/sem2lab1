using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DapperRepository : IRepository<DrugBuyer>
    {
        public void Add(string name, string district, string drug)
        {
            //ИМОРЛАРЛОЫРПЛОЫВРПОЛЫВ
        }

        public void Delete(int Id)
        {

        }

        public List<DrugBuyer> ReadAll()
        {
            return new List<DrugBuyer>();
        }

        public DrugBuyer ReadByID(int Id)
        {
            return new DrugBuyer(1,"","","");
        }

        public void Update(DrugBuyer drugBuyer)
        {

        }
    }
}
