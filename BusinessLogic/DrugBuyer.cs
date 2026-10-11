using System;

namespace BusinessLogic
{
    public class DrugBuyer : IDomainObject
    {
        public DrugBuyer(int id, string name, string district, string favouriteDrug)
        {
            Id = id;
            Name = name;
            District = district;
            FavouriteDrug = favouriteDrug;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string District { get; private set; }
        public string FavouriteDrug { get; private set; }

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
