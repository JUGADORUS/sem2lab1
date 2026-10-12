using System;
using System.Collections.Generic;

namespace Model
{
    public class DrugLaboratory
    {
        private readonly IRepository<DrugBuyer> _repository;
        private static readonly Random _random = new Random();

        public DrugLaboratory(IRepository<DrugBuyer> repository) 
        {
            _repository = repository;

            SeedDatabase();
        }

        /// <summary> Получает список уникальных котиков </summary>
        /// <returns> Возвращает список строк с уникальными котиками </returns>
        public List<string> GetUniqueDrugs() 
        {
            List<string> result = new List<string>();

            foreach (DrugBuyer buyer in _repository.ReadAll()) 
            {
                if (!result.Contains(buyer.FavouriteDrug)) 
                {
                    result.Add(buyer.FavouriteDrug);
                }
            }

            return result;
        }

        /// <summary> Получает список покупателей по их любимому котику </summary>
        /// <param name="drug"> Любимый котик </param>
        /// <returns> Возвращает список покупателей по их любимому котику </returns>
        public List<DrugBuyer> GetBuyersByDrug(string drug) 
        {   
            List<DrugBuyer> result = new List<DrugBuyer>();

            foreach(DrugBuyer buyer in _repository.ReadAll()) 
            {
                if (buyer.FavouriteDrug == drug) 
                {
                    result.Add(buyer);
                }
            }

            return result;
        }

        /// <summary> Получает статистику по районам и их популярности </summary>
        /// <returns> Возвращает словарь в котором ключ - район, а значение - словарь,
        /// в котором ключ - котик, а значение - количество появлений</returns>
        public Dictionary<string, Dictionary<string, int>> GetDistrictStatistics() 
        {
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();

            foreach(DrugBuyer buyer in _repository.ReadAll()) 
            {
                string district = buyer.District;
                string drug = buyer.FavouriteDrug;

                if (!result.ContainsKey(district)) 
                {
                    result[district] = new Dictionary<string, int>();
                }

                if (!result[district].ContainsKey(drug)) 
                {
                    result[district][drug] = 1;
                }
                else 
                {
                    result[district][drug]++;
                }
            }

            return result;
        }

        /// <summary> Добавить нового покупателя </summary>
        /// <param name="name"> Имя</param>
        /// <param name="district"> Район</param>
        /// <param name="drug"> Котик</param>
        public void AddNewBuyer(string name, string district, string drug)
        {
            int id = GenerateUniqueId();

            DrugBuyer drugBuyer = new DrugBuyer()
            {
                Id = id,
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

        private int GenerateUniqueId()
        {
            int newId;

            do
            {
                newId = _random.Next(10000, 100000);
            }
            while (FindBuyerById(newId) != null);

            return newId;
        }

        private void SeedDatabase()
        {
            List<DrugBuyer> initialBuyers = new List<DrugBuyer>
            {
                new DrugBuyer { Id = 0, Name = "Слим Шейди", District = "Бронкс", FavouriteDrug = "Кокаин" },
                new DrugBuyer { Id = 0, Name = "Крэк-Кит", District = "Бруклин", FavouriteDrug = "Кокаин" },
                new DrugBuyer { Id = 0, Name = "Ломанный Зуб", District = "Бронкс", FavouriteDrug = "Мет" },
                new DrugBuyer { Id = 0, Name = "Химозный Рон", District = "Беверли Хиллз", FavouriteDrug = "Фентанил" },
                new DrugBuyer { Id = 0, Name = "Мет-Молли", District = "Бронкс", FavouriteDrug = "Мет" },
                new DrugBuyer { Id = 0, Name = "Фентанил Фред", District = "Беверли Хиллз", FavouriteDrug = "Фентанил" },
                new DrugBuyer { Id = 0, Name = "Стеклянный Глаз", District = "Бруклин", FavouriteDrug = "Мет" },
                new DrugBuyer { Id = 0, Name = "Пузырь", District = "Бронкс", FavouriteDrug = "Кокаин" },
                new DrugBuyer { Id = 0, Name = "Твич", District = "Бруклин", FavouriteDrug = "Фентанил" },
                new DrugBuyer { Id = 0, Name = "Белый Кролик", District = "Бруклин", FavouriteDrug = "Кокаин" }
            };

            foreach (var buyer in initialBuyers)
            {
                _repository.Add(buyer);
            }
        }
    }
}
