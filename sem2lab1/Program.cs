using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Model;

namespace sem2lab1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            const string AddNewBuyerCommand = "1";
            const string RemoveClientCommand = "2";
            const string ReadClientInfoCommand = "3";
            const string ChangeClientInfoCommand = "4";
            const string ShowAllClientsInfoCommand = "5";
            const string GroupByFavouriteDrugCommand = "6";
            const string ShowDistrictStatisticsCommand = "7";

            DrugLaboratory drugLaboratory = new DrugLaboratory();

            while (true)
            {
                Continue();
                Console.Clear();

                Console.WriteLine($"Что вы хотите сделать?\n" +
                    $"{AddNewBuyerCommand} - Добавить нового клиента в базу\n" +
                    $"{RemoveClientCommand} - Ликвидировать клиента\n" +
                    $"{ReadClientInfoCommand} - Пробить клиента по глазу бога\n" +
                    $"{ChangeClientInfoCommand} - Внушить клиенту новую информацию\n" +
                    $"{ShowAllClientsInfoCommand} - Показать информацию о всех клиентах\n" +
                    $"{GroupByFavouriteDrugCommand} - Группировать по любимому котику\n" +
                    $"{ShowDistrictStatisticsCommand} - Подвести статистику по районам\n");

                string UserInput = Console.ReadLine();

                Console.Clear();

                switch (UserInput)
                {
                    case AddNewBuyerCommand:
                        AddNewClient(drugLaboratory);
                        break;

                    case RemoveClientCommand:
                        RemoveClient(drugLaboratory);
                        break;

                    case ReadClientInfoCommand:
                        ReadClientInfo(drugLaboratory);
                        break;

                    case ShowAllClientsInfoCommand:
                        ShowAllClients(drugLaboratory);
                        break;

                    case ChangeClientInfoCommand:
                        ChangeClientInformation(drugLaboratory);
                        break;

                    case GroupByFavouriteDrugCommand:
                        GroupByFavouriteDrug(drugLaboratory);
                        break;

                    case ShowDistrictStatisticsCommand:
                        GetDistrictStatistics(drugLaboratory);
                        break;

                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }

        private static void AddNewClient(DrugLaboratory drugLaboratory)
        {
            Console.WriteLine("Введите имя нового торчка: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите район нового торчка: ");
            string district = Console.ReadLine();
            Console.WriteLine("Введите любимый котик нового торчка: ");
            string drug = Console.ReadLine();

            drugLaboratory.AddNewBuyer(name, district, drug);
        }

        private static void RemoveClient(DrugLaboratory drugLaboratory)
        {
            List<DrugBuyer> drugBuyers = drugLaboratory.GetAllBuyers();
            Console.WriteLine("Кого вы хотите ликвидировать? Введите индекс: ");

            ShowAllClients(drugLaboratory);

            if(int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < drugBuyers.Count)
            {
                Console.WriteLine($"{drugBuyers[index].Name} успешно ликвидирован");
                drugLaboratory.RemoveBuyer(drugLaboratory.GetAllBuyers()[index]);
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private static void ReadClientInfo(DrugLaboratory drugLaboratory)
        {
            List<DrugBuyer> drugBuyers = drugLaboratory.GetAllBuyers();
            Console.WriteLine("Кого вы хотите проверить с глазом бога? Введите индекс: ");

            ShowAllClients(drugLaboratory);

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < drugBuyers.Count)
            {
                Console.WriteLine($"{index} - {drugBuyers[index].Name}, район - {drugBuyers[index].District}, любимый котик - {drugBuyers[index].FavouriteDrug}");
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private static void ChangeClientInformation(DrugLaboratory drugLaboratory)
        {
            List<DrugBuyer> drugBuyers = drugLaboratory.GetAllBuyers();
            Console.WriteLine("У кого вы хотите изменить информацию? Введите индекс: ");

            ShowAllClients(drugLaboratory);

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < drugBuyers.Count)
            {
                Console.WriteLine($"{index} - {drugBuyers[index].Name}, район - {drugBuyers[index].District}, любимый котик - {drugBuyers[index].FavouriteDrug}\n" +
                    $"Изменение информации торчка:\nВведите имя торчка: ");
                string name = Console.ReadLine();
                Console.WriteLine("Введите район торчка: ");
                string district = Console.ReadLine();
                Console.WriteLine("Введите любимый котик нового торчка: ");
                string drug = Console.ReadLine();

                drugLaboratory.ChangeInformation(name, district, drug, drugLaboratory.GetAllBuyers()[index]);
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private static void ShowAllClients(DrugLaboratory drugLaboratory)
        {
            List<DrugBuyer> drugBuyers = drugLaboratory.GetAllBuyers();

            for (int i = 0; i < drugBuyers.Count; i++)
            {
                Console.WriteLine($"{i} - {drugBuyers[i].Name}");
            }
        }

        private static void GetDistrictStatistics(DrugLaboratory drugLaboratory)
        {
            List<string> districts = drugLaboratory.GetUniqueDistrict();

            foreach (string district in districts)
            {
                List<DrugBuyer> drugBuyers = drugLaboratory.GetBuyersByDistrict(district);
                Dictionary<string,int> drugPopularity = new Dictionary<string,int>();
                List<string> uniqueDrugs = drugLaboratory.GetUniqueDrug();

                foreach(string drug in uniqueDrugs)
                {
                    drugPopularity.Add(drug,0);
                }

                for (int i = 0; i < drugBuyers.Count; i++)
                {
                    drugPopularity[drugBuyers[i].FavouriteDrug]++;
                }

                var sortedPopularity = drugPopularity.OrderByDescending(pair => pair.Value);
                Console.WriteLine($"Район: {district}");

                foreach (var pair in sortedPopularity)
                {
                    if (pair.Value > 0)
                    {
                        Console.WriteLine($"{pair.Key}, любимый у {pair.Value} людей");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void GroupByFavouriteDrug(DrugLaboratory drugLaboratory)
        {
            List<string> uniqueDrugs = drugLaboratory.GetUniqueDrug();

            foreach(string drug in uniqueDrugs)
            {
                List<DrugBuyer> drugBuyers = drugLaboratory.GetBuyersByDrug(drug);

                Console.WriteLine($"Любимый наркотик: {drug}");

                foreach( DrugBuyer drugBuyer in drugBuyers)
                {
                    Console.WriteLine($"{drugBuyer.Name}, район - {drugBuyer.District}");
                }

                Console.WriteLine();
            }
        }

        private static void Continue()
        {
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
        }
    }
}
