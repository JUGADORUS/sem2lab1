using System.Collections.Generic;
using Model;
using DataAccessLayer;

namespace BusinesssLogic
{
    public class DrugLaboratory
    {
        private readonly IRepository<DrugBuyer> _repository;

        public DrugLaboratory(IRepository<DrugBuyer> repository) 
        {
            _repository = repository;
        }

        /// <summary> Добавить нового покупателя </summary>
        /// <param name="name"> Имя</param>
        /// <param name="district"> Район</param>
        /// <param name="drug"> Котик</param>
        public void AddNewBuyer(string name, string district, string drug)
        {
            DrugBuyer drugBuyer = new DrugBuyer()
            {
                Id = 0,
                Name = name,
                District = district,
                FavouriteDrug = drug
            };

            _repository.Add(drugBuyer);
        }

        /// <summary> Находит покупателя по ID </summary>
        /// <param name="id"> id</param>
        /// <returns> Возвращает покупателя с нужным ID </returns>
        public DrugBuyer FindBuyerById(int id)
        {
            return _repository.ReadById(id);
        }

        /// <summary> Убирает покупателя из списка по Id </summary>
        /// <param name="id"> Id покупателя </param>
        /// <returns> true, если покупатель найден и удалён; иначе false </returns>
        public bool RemoveBuyer(int id)
        {
            DrugBuyer buyer = _repository.ReadById(id);
            if (buyer == null)
                return false;

            _repository.Delete(id);
            return true;
        }

        /// <summary> Получает список всех покупателей </summary>
        /// <returns> Возвращает список всех покупателей </returns>
        public List<DrugBuyer> GetAllBuyers()
        {
            List<DrugBuyer> tempList = new List<DrugBuyer>();

            foreach(DrugBuyer drugBuyer in _repository.ReadAll())
            {
                tempList.Add(drugBuyer);
            }

            return tempList;
        }

        /// <summary> Меняет имя на новое</summary>
        /// <param name="name"> Имя </param>
        /// <param name="id"> id </param>
        public void ChangeName(string name, int id)
        {
            DrugBuyer buyer = FindBuyerById(id);
            if (buyer != null)
            {
                buyer.ChangeName(name);
                _repository.Update(buyer);
            }
        }

        //// <summary> Меняет район на новый</summary>
        /// <param name="district"> Район</param>
        /// <param name="id"> id </param>
        public void ChangeDistrict(string district, int id)
        {
            DrugBuyer buyer = FindBuyerById(id);
            if (buyer != null)
            {
                buyer.ChangeDistrict(district);
                _repository.Update(buyer);
            }
        }

        /// <summary> Меняет любимый наркотик на новый</summary>
        /// <param name="favouriteDrug"> Любимый котик </param>
        /// <param name="id"> id </param>
        public void ChangeFavouriteDrug(string favouriteDrug, int id)
        {
            DrugBuyer buyer = FindBuyerById(id);
            if (buyer != null)
            {
                buyer.ChangeFavouriteDrug(favouriteDrug);
                _repository.Update(buyer);
            }
        }
    }
}
