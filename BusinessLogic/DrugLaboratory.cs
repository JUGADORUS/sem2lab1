using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace sem2lab1
{
    internal class DrugLaboratory
    {
        private List<DrugBuyer> _buyers = new List<DrugBuyer>();

        public DrugLaboratory() 
        {
            AddBuyers();
        }

        public void AddNewBuyer(string name, string district,string drug)
        {
            _buyers.Add(new DrugBuyer(name, district, drug));
        }

        private void GroupByFavouriteDrug()
        {
            var groups = _buyers.GroupBy(buyer => buyer.FavouriteDrug);

            foreach (var group in groups)
            {
                Console.WriteLine($"Любимый наркотик: {group.Key}");

                foreach (var buyer in group)
                {
                    Console.WriteLine($"{buyer.Name}, его район: ({buyer.District})");
                }
            }
        }

        private void RemoveBuyer(int index)
        {
            _buyers.RemoveAt(index);
        }


        private string GetAllBuyers()
        {
            string buyersInfo = "";

            for(int i = 0; i < _buyers.Count; i++)
            {
                buyersInfo = buyersInfo + ($"{_buyers[i].Name}. Геолокация - {_buyers[i].District}. Любимый наркотик - {_buyers[i].FavouriteDrug}\n");
            }

            return buyersInfo;
        }

        private void ShowBuyer()
        {

            Console.WriteLine("Чье досье вам нужно? Введите индекс");

            if (int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine($"{_buyers[index].Name}. Любимый наркотик - {_buyers[index].FavouriteDrug}, он с района: {_buyers[index].District}");
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

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
        }
    }
}
