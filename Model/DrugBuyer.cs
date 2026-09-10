using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem2lab1
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
    }
}
