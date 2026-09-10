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

        private string GroupByFavouriteDrug()
        {
            var groups = _buyers.GroupBy(buyer => buyer.FavouriteDrug);
            string groupsInfo = "";

            foreach (var group in groups)
            {
                groupsInfo += $"Любимый наркотик: {group.Key}\n";

                foreach (var buyer in group)
                {
                    groupsInfo += $"{buyer.Name}, его район: {buyer.District}\n";
                }

                groupsInfo += "\n";
            }

            return groupsInfo;
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

        private string ShowBuyer(int index)
        {
            return $"{_buyers[index].Name}. Любимый наркотик - {_buyers[index].FavouriteDrug}, он с района: {_buyers[index].District}";
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
