using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{   
    public class DrugBuyer
    {
        public DrugBuyer(string name, string district, string favouriteDrug)
        {
            Name = name;
            District = district;
            FavouriteDrug = favouriteDrug;
        }

        public string Name { get; set; }
        public string District { get; set; }
        public string FavouriteDrug { get; set; }

        /// <summary> Меняет информацию на новую</summary>
        /// <param name="name"> Имя </param>
        /// <param name="district"> Район</param>
        /// <param name="favouriteDrug"> Любимый котик </param>
        public void ChangeInformation(string name, string district, string favouriteDrug)
        {
            Name = name;
            District = district;
            FavouriteDrug = favouriteDrug;
        }
    }
}
