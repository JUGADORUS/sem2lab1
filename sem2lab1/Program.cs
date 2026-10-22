using BusinesssLogic;
using Model;
using System;
using System.Collections.Generic;
using Ninject;


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

            const bool isEntityFramework = false;

            IKernel kernel = NinjectConfig.CreateKernel(isEntityFramework);

            DrugLaboratory drugLaboratory = kernel.Get<DrugLaboratory>();
            DrugStatisticsService statisticsService = kernel.Get<DrugStatisticsService>();

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
                        GroupByFavouriteDrug(statisticsService);
                        break;

                    case ShowDistrictStatisticsCommand:
                        GetDistrictStatistics(statisticsService);
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
            Console.WriteLine("Кого вы хотите ликвидировать? Введите Id: ");
            ShowAllClients(drugLaboratory);

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (drugLaboratory.RemoveBuyer(id))
                {
                    Console.WriteLine("Клиент успешно ликвидирован");
                }
                else
                {
                    Console.WriteLine("Клиент с таким Id не найден");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private static void ReadClientInfo(DrugLaboratory drugLaboratory)
        {
            Console.WriteLine("Кого вы хотите проверить с глазом бога? Введите Id: ");
            ShowAllClients(drugLaboratory);

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                DrugBuyer buyer = drugLaboratory.FindBuyerById(id);

                if (buyer != null)
                {
                    Console.WriteLine($"ID:{buyer.Id} - {buyer.Name}, район - {buyer.District}, любимый котик - {buyer.FavouriteDrug}");
                }
                else
                {
                    Console.WriteLine("Клиент с таким Id не найден");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private static void ChangeClientInformation(DrugLaboratory drugLaboratory)
        {
            Console.WriteLine("У кого вы хотите изменить информацию? Введите ID: ");

            ShowAllClients(drugLaboratory);

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                DrugBuyer drugBuyer = drugLaboratory.FindBuyerById(id);

                if (drugBuyer == null)
                {
                    Console.WriteLine("Клиент с таким Id не найден");
                    return;
                }

                string name = drugBuyer.Name;
                string district = drugBuyer.District;
                string drug = drugBuyer.FavouriteDrug;

                Console.WriteLine($"ID:{id} - {name}, район - {district}, любимый котик - {drug}\n" +
                    $"Изменение информации торчка");

                string newName = GetProperty("имя", name);
                if (newName != name)
                {
                    drugLaboratory.ChangeName(newName, id);
                }

                string newDistrict = GetProperty("район", district);
                if (newDistrict != district)
                {
                    drugLaboratory.ChangeDistrict(newDistrict, id);
                }

                string newDrug = GetProperty("котик", drug);
                if (newDrug != drug)
                {
                    drugLaboratory.ChangeFavouriteDrug(newDrug, id);
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private static string GetProperty(string property, string oldProperty)
        {
            string userInput = "";
            string newValueOfProperty = "";

            while(userInput != "y" && userInput != "n")
            {
                Console.WriteLine($"Вы хотите изменить {property}? y/n");
                userInput = Console.ReadLine();
            }

            if (userInput == "y")
            {
                Console.WriteLine($"Введите новое значение: {property}");
                
                while(newValueOfProperty == "")
                {
                    newValueOfProperty = Console.ReadLine();
                }

                return newValueOfProperty;
            }
            else
            {
                return oldProperty;
            }
        }

        private static void ShowAllClients(DrugLaboratory drugLaboratory)
        {
            List<DrugBuyer> drugBuyers = drugLaboratory.GetAllBuyers();

            foreach (DrugBuyer buyer in drugBuyers)
            {
                Console.WriteLine($"ID:{buyer.Id} - {buyer.Name}");
            }
        }

        private static void GetDistrictStatistics(DrugStatisticsService statisticsService)
        {
            Dictionary<string, Dictionary<string, int>> stats = statisticsService.GetDistrictStatistics();

            foreach( var district in stats) 
            {
                Console.WriteLine($"Район: {district.Key}");

                foreach(var drug in district.Value) 
                {
                    Console.WriteLine($"{drug.Key}, любимый у {drug.Value} людей.");
                }

                Console.WriteLine();
            }
        }

        private static void GroupByFavouriteDrug(DrugStatisticsService statisticsService)
        {
            List<string> uniqueDrugs = statisticsService.GetUniqueDrugs();

            foreach(string drug in uniqueDrugs)
            {
                List<DrugBuyer> drugBuyers = statisticsService.GetBuyersByDrug(drug);

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
