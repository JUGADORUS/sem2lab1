using System.Collections.Generic;
using Model;

namespace BusinessLogic
{
    public class DrugLaboratory
    {
        private List<DrugBuyer> _buyers = new List<DrugBuyer>();

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
        /// <param name="name"> Имя </param>
        /// <param name="district"> Район </param>
        /// <param name="drug"> Котик </param>
        public void AddNewBuyer(string name, string district,string drug)
        {
            _buyers.Add(new DrugBuyer(name, district, drug));
        }


        /// <summary> Убирает покупателя из списка</summary>
        /// <param name="buyer"> Клиент </param>
        public void RemoveBuyer(DrugBuyer buyer)
        {
            _buyers.Remove(buyer);
        }

        /// <summary> Получает список всех покупателей </summary>
        /// <returns> Возвращает список всех покупателей </returns>
        public List<DrugBuyer> GetAllBuyers()
        {
            return _buyers;
        }

        /// <summary> Меняет информацию покупателя </summary>
        /// <param name="name"> Имя </param>
        /// <param name="district"> Район</param>
        /// <param name="favouriteDrug"> Любимый котик </param>
        /// <param name="drugBuyer"> Клиент </param>
        public void ChangeInformation(string name, string district, string favouriteDrug, DrugBuyer drugBuyer)
        {
            drugBuyer.ChangeInformation(name, district, favouriteDrug);
        }

        /// <summary> Добавляет покупателей в так называемую базу данных</summary>
        private void AddBuyers()
        {
            _buyers.Add(new DrugBuyer("Слим Шейди", "Бронкс", "Кокаин"));
            _buyers.Add(new DrugBuyer("Крэк-Кит", "Бруклин", "Кокаин"));
            _buyers.Add(new DrugBuyer("Ломанный Зуб", "Бронкс", "Мет"));
            _buyers.Add(new DrugBuyer("Химозный Рон", "Беверли Хиллз", "Фентанил"));
            _buyers.Add(new DrugBuyer("Мет-Молли", "Бронкс", "Мет"));
            _buyers.Add(new DrugBuyer("Фентанил Фред", "Беверли Хиллз", "Фентанил"));
            _buyers.Add(new DrugBuyer("Стеклянный Глаз", "Бруклин", "Мет"));
            _buyers.Add(new DrugBuyer("Пузырь", "Бронкс", "Кокаин"));
            _buyers.Add(new DrugBuyer("Твич", "Бруклин", "Фентанил"));
            _buyers.Add(new DrugBuyer("Белый Кролик", "Бруклин", "Кокаин"));
            _buyers.Add(new DrugBuyer("Железный Нос", "Беверли Хиллз", "Мет"));
            _buyers.Add(new DrugBuyer("Пепел", "Бронкс", "Фентанил"));
            _buyers.Add(new DrugBuyer("Кислый Стив", "Бруклин", "Экстази"));
            _buyers.Add(new DrugBuyer("Мармеладный Джо", "Бруклин", "Экстази"));
            _buyers.Add(new DrugBuyer("Танцор Дэн", "Бруклин", "Экстази"));
            _buyers.Add(new DrugBuyer("Бледный Пит", "Бруклин", "Героин"));
            _buyers.Add(new DrugBuyer("Джазмен Лу", "Гарлем", "Трава"));
            _buyers.Add(new DrugBuyer("Дымный Бигги", "Гарлем", "Трава"));
            _buyers.Add(new DrugBuyer("Глухой Снуп", "Гарлем", "Трава"));
            _buyers.Add(new DrugBuyer("Лысый Тупак", "Гарлем", "Трава"));
            _buyers.Add(new DrugBuyer("Игла-Мэри", "Гарлем", "Героин"));
            _buyers.Add(new DrugBuyer("Сонный Джим", "Гарлем", "Героин"));
            _buyers.Add(new DrugBuyer("Грибной Шroom", "Квинс", "Грибы"));
            _buyers.Add(new DrugBuyer("Алиса в Космосе", "Квинс", "Грибы"));
            _buyers.Add(new DrugBuyer("Шаман Боб", "Квинс", "Грибы"));
            _buyers.Add(new DrugBuyer("Быстрый Чеки", "Квинс", "Кокаин"));
            _buyers.Add(new DrugBuyer("Шустрый Ли", "Квинс", "Мет"));
            _buyers.Add(new DrugBuyer("Лоурайдер Си-Джей", "Комптон", "Трава"));
            _buyers.Add(new DrugBuyer("Гангстер Райдер", "Комптон", "Трава"));
            _buyers.Add(new DrugBuyer("Сладкий Эрик", "Комптон", "Трава"));
            _buyers.Add(new DrugBuyer("Бешеный Пес", "Комптон", "Кокаин"));
            _buyers.Add(new DrugBuyer("Дриблинг О-Джи", "Комптон", "Фентанил"));
            _buyers.Add(new DrugBuyer("Ржавый Эминем", "Детройт", "Мет"));
            _buyers.Add(new DrugBuyer("Гайка-Гарри", "Детройт", "Мет"));
            _buyers.Add(new DrugBuyer("Заводской Сэм", "Детройт", "Героин"));
            _buyers.Add(new DrugBuyer("Мрачный Эд", "Детройт", "Героин"));
            _buyers.Add(new DrugBuyer("Колесный Макс", "Бронкс", "Экстази"));
            _buyers.Add(new DrugBuyer("Трясущийся Билл", "Бронкс", "Мет"));
            _buyers.Add(new DrugBuyer("Дымный Тони", "Бронкс", "Трава"));
            _buyers.Add(new DrugBuyer("Мажор Алекс", "Беверли Хиллз", "Кокаин"));
            _buyers.Add(new DrugBuyer("Модель Кристи", "Беверли Хиллз", "Кокаин"));
            _buyers.Add(new DrugBuyer("Пластиковый Том", "Беверли Хиллз", "Фентанил"));
            _buyers.Add(new DrugBuyer("Звездный Дэнни", "Беверли Хиллз", "Грибы"));
            _buyers.Add(new DrugBuyer("Диджей Рокс", "Беверли Хиллз", "Экстази"));
        }
    }
}
