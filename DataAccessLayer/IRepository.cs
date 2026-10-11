using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace DataAccessLayer
{
    internal interface IRepository<T> where T : IDomainObject
    {
        void Add(string name, string district, string drug);
        void Delete(int id);
        void ReadAll();
        void ReadByID(int id);
        void Update();
    }
}
