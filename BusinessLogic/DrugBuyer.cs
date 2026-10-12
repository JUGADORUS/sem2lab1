using System;

namespace Model
{
    public class DrugBuyer : IDomainObject
    {
        public DrugBuyer(){}

        public int Id { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        public string FavouriteDrug { get; set; }

        /// <summary> Меняет имя на новое</summary>
        /// <param name="name"> Имя </param>
        public void ChangeName(string name)
        {
            Name = name;
        }

        /// <summary> Меняет район на новый</summary>
        /// <param name="district"> Район</param>
        public void ChangeDistrict(string district)
        {
            District = district;
        }

        /// <summary> Меняет любимый наркотик на новый</summary>
        /// <param name="favouriteDrug"> Любимый котик </param>
        public void ChangeFavouriteDrug(string favouriteDrug)
        {
            FavouriteDrug = favouriteDrug;
        }
    }
}
