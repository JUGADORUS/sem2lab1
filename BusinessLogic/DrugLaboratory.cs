using Model;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class DrugLaboratory
    {
        private List<DrugBuyer> _buyers = new List<DrugBuyer>();
        private static readonly Random _random = new Random();

        public DrugLaboratory() 
        {
            AddBuyers();
        }

        /// <summary> Получает список уникальных котиков </summary>
        /// <returns> Возвращает список строк с уникальными котиками </returns>
        public List<string> GetUniqueDrugs() 
        {
            List<string> result = new List<string>();

            foreach (DrugBuyer buyer in _buyers) 
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

            foreach(DrugBuyer buyer in _buyers) 
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

            foreach(DrugBuyer buyer in _buyers) 
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
        public void AddNewBuyer(string name, string district,string drug)
        {
            int id = GenerateUniqueId();
            _buyers.Add(new DrugBuyer(id, name, district, drug));
        }

        /// <summary> Находит покупателя по ID </summary>
        /// <param name="id"> id</param>
        /// <returns> Возвращает покупателя с нужным ID </returns>
        public DrugBuyer FindBuyerById(int id)
        {
            foreach (DrugBuyer buyer in _buyers)
            {
                if (buyer.Id == id)
                    return buyer;
            }

            return null;
        }


        /// <summary> Убирает покупателя из списка по Id </summary>
        /// <param name="id"> Id покупателя </param>
        /// <returns> true, если покупатель найден и удалён; иначе false </returns>
        public bool RemoveBuyer(int id)
        {
            DrugBuyer buyer = FindBuyerById(id);
            if (buyer == null)
                return false;

            _buyers.Remove(buyer);
            return true;
        }

        /// <summary> Получает список всех покупателей </summary>
        /// <returns> Возвращает список всех покупателей </returns>
        public List<DrugBuyer> GetAllBuyers()
        {
            List<DrugBuyer> tempList = new List<DrugBuyer>();

            foreach(DrugBuyer drugBuyer in _buyers)
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
                buyer.ChangeName(name);
        }

        //// <summary> Меняет район на новый</summary>
        /// <param name="district"> Район</param>
        /// <param name="id"> id </param>
        public void ChangeDistrict(string district, int id)
        {
            DrugBuyer buyer = FindBuyerById(id);
            if (buyer != null)
                buyer.ChangeDistrict(district);
        }

        /// <summary> Меняет любимый наркотик на новый</summary>
        /// <param name="favouriteDrug"> Любимый котик </param>
        /// <param name="id"> id </param>
        public void ChangeFavouriteDrug(string favouriteDrug, int id)
        {
            DrugBuyer buyer = FindBuyerById(id);
            if (buyer != null)
                buyer.ChangeFavouriteDrug(favouriteDrug);
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

        /// <summary> Добавляет покупателей в так называемую базу данных</summary>
        private void AddBuyers()
        {
            _buyers.Add(new DrugBuyer(48213, "Слим Шейди", "Бронкс", "Кокаин"));
            _buyers.Add(new DrugBuyer(91045, "Крэк-Кит", "Бруклин", "Кокаин"));
            _buyers.Add(new DrugBuyer(30117, "Ломанный Зуб", "Бронкс", "Мет"));
            _buyers.Add(new DrugBuyer(73642, "Химозный Рон", "Беверли Хиллз", "Фентанил"));
            _buyers.Add(new DrugBuyer(15890, "Мет-Молли", "Бронкс", "Мет"));
            _buyers.Add(new DrugBuyer(62408, "Фентанил Фред", "Беверли Хиллз", "Фентанил"));
            _buyers.Add(new DrugBuyer(87931, "Стеклянный Глаз", "Бруклин", "Мет"));
            _buyers.Add(new DrugBuyer(40576, "Пузырь", "Бронкс", "Кокаин"));
            _buyers.Add(new DrugBuyer(29384, "Твич", "Бруклин", "Фентанил"));
            _buyers.Add(new DrugBuyer(56712, "Белый Кролик", "Бруклин", "Кокаин"));
            _buyers.Add(new DrugBuyer(74059, "Железный Нос", "Беверли Хиллз", "Мет"));
            _buyers.Add(new DrugBuyer(18627, "Пепел", "Бронкс", "Фентанил"));
            _buyers.Add(new DrugBuyer(93250, "Кислый Стив", "Бруклин", "Экстази"));
            _buyers.Add(new DrugBuyer(36148, "Мармеладный Джо", "Бруклин", "Экстази"));
            _buyers.Add(new DrugBuyer(50873, "Танцор Дэн", "Бруклин", "Экстази"));
            _buyers.Add(new DrugBuyer(21495, "Бледный Пит", "Бруклин", "Героин"));
            _buyers.Add(new DrugBuyer(67381, "Джазмен Лу", "Гарлем", "Трава"));
            _buyers.Add(new DrugBuyer(84026, "Дымный Бигги", "Гарлем", "Трава"));
            _buyers.Add(new DrugBuyer(12964, "Глухой Снуп", "Гарлем", "Трава"));
            _buyers.Add(new DrugBuyer(49537, "Лысый Тупак", "Гарлем", "Трава"));
        }
    }
}
