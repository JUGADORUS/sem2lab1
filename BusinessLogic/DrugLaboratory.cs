using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public List<string> GetUniqueDrug() 
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
        public void AddNewBuyer(string name, string district,string drug)
        {
            _buyers.Add(new DrugBuyer(name, district, drug));
        }

        private string ShowBuyer(int index)
        {
            return $"{_buyers[index].Name}. Любимый наркотик - {_buyers[index].FavouriteDrug}, он с района: {_buyers[index].District}";
        }

        //Здесь тоже изменила метод с индекса на самого покупателя.
        public void RemoveBuyer(DrugBuyer buyer)
        {
            _buyers.Remove(buyer);
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

        public List<DrugBuyer> GetAllBuyers()
        {
            /*Я поменяла этот метод т.к. по тз необходимо пользоваться одним методом для вывода и на WinForms
            и в консоль. Мне необходим сам список, а не строка, поэтому при выводе в консоль используй код ниже?,
            ну или измени как тебе удобно:
            */

            //DrugLaboratory lab = new DrugLaboratory();
            //foreach (var buyer in lab.GetAllBuyers())
            //{
            //    Console.WriteLine($"{buyer.Name}. Геолокация - {buyer.District}. Любимый наркотик - {buyer.FavouriteDrug}");
            //}

            //Старый код
            //string buyersInfo = "";

            //for(int i = 0; i < _buyers.Count; i++) 
            //{
            //    buyersInfo += $"{_buyers[i].Name}. Геолокация - {_buyers[i].District}. Любимый наркотик - {_buyers[i].FavouriteDrug}\n"; 
            //}

            //return buyersInfo;

            return _buyers;
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
