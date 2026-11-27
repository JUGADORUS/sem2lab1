using System;
using System.Collections.Generic;
using Shared;


namespace sem2lab1
{
    public class ConsoleView: IView
    {
        public event EventHandler<DrugBuyerEventArgs> AddBuyerRequested;
        public event EventHandler<DrugBuyerEventArgs> RemoveBuyerRequested;
        public event EventHandler<DrugBuyerEventArgs> UpdateBuyerRequested;
        public event EventHandler AllBuyersRequested;
        public event EventHandler<DrugBuyerEventArgs> BuyersByDrugRequested;
        public event EventHandler StatisticsRequested;

        /// <summary> Отображает список покупателей </summary>
        /// <param name="buyers"> список DTO покупателей для отображения.</param>
        public void ShowBuyers(List<DrugBuyerDto> buyers)
        {
            Console.WriteLine("\nСписок клиентов:");
            foreach (var b in buyers)
            {
                Console.WriteLine($"ID:{b.Id} [ {b.Name} | Район: {b.District} | Котик: {b.FavouriteDrug}]");
            }
        }

        /// <summary> Отображает список c названиями наркотиков </summary>
        /// <param name="drugs"> список строк с названиями наркотиков </param>
        public void ShowDrugs(List<string> drugs)
        {
            Console.WriteLine("\nУникальные наркотики:");
            foreach (var d in drugs)
            {
                Console.WriteLine($"- {d}");
            }
        }

        /// <summary> Выводит статистику по районам </summary>
        /// <param name="statistics"> словарь, где ключ - район,значение - словарь с наркотиками и их количеством </param>
        public void ShowStatistics(Dictionary<string, Dictionary<string, int>> statistics)
        {
            Console.WriteLine("\nСтатистика по районам:");
            foreach (var district in statistics)
            {
                Console.WriteLine($"Район: {district.Key}");
                foreach (var drug in district.Value)
                {
                    Console.WriteLine($"  {drug.Key}: {drug.Value} чел.");
                }
            }
        }

        /// <summary>  Выводит messageBox с сообщением пользователю </summary>
        /// <param name="message"> Текст сообщения для отображения </param>
        public void ShowMessage(string message)
        {
            Console.WriteLine($"[Сообщение]: {message}");
        }

        /// <summary> Запускает и ведет основной цикл работы ConsoleView </summary>
        public void Run()
        {
            const string AddNewBuyerCommand = "1";
            const string RemoveClientCommand = "2";
            const string ReadClientInfoCommand = "3";
            const string ChangeClientInfoCommand = "4";
            const string ShowAllClientsInfoCommand = "5";
            const string GroupByFavouriteDrugCommand = "6";
            const string ShowDistrictStatisticsCommand = "7";


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
                        AddNewClient();
                        break;

                    case RemoveClientCommand:
                        RemoveClient();
                        break;

                    //case ReadClientInfoCommand:
                    //    ReadClientInfo();
                    //    break;

                    case ShowAllClientsInfoCommand:
                        ShowAllClients();
                        break;

                    case ChangeClientInfoCommand:
                        ChangeClientInformation();
                        break;

                    case GroupByFavouriteDrugCommand:
                        GroupByFavouriteDrug();
                        break;

                    case ShowDistrictStatisticsCommand:
                        GetDistrictStatistics();
                        break;

                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
        }

        private void AddNewClient()
        {
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            Console.Write("Район: ");
            string district = Console.ReadLine();
            Console.Write("Котик: ");
            string drug = Console.ReadLine();

            DrugBuyerDto dto = new DrugBuyerDto { Name = name, District = district, FavouriteDrug = drug };
            AddBuyerRequested?.Invoke(this, new DrugBuyerEventArgs(dto));
        }

        private void RemoveClient()
        {
            Console.WriteLine("Кого вы хотите ликвидировать? Введите Id: ");
            ShowAllClients();

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                DrugBuyerDto dto = new DrugBuyerDto { Id = id };
                RemoveBuyerRequested?.Invoke(this, new DrugBuyerEventArgs(dto));
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        //private void ReadClientInfo()
        //{
        //    Console.WriteLine("Кого вы хотите проверить с глазом бога? Введите Id: ");
        //    ShowAllClients();

        //    if (int.TryParse(Console.ReadLine(), out int id))
        //    {
        //        DrugBuyerDto buyer = drugLaboratory.FindBuyerById(id);

        //        if (buyer != null)
        //        {
        //            Console.WriteLine($"ID:{buyer.Id} - {buyer.Name}, район - {buyer.District}, любимый котик - {buyer.FavouriteDrug}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Клиент с таким Id не найден");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Неверный ввод");
        //    }
        //}

        private void ChangeClientInformation()
        {
            Console.WriteLine("У кого вы хотите изменить информацию? Введите ID: ");
            ShowAllClients();

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Новое имя (Enter - не менять): ");
                string name = Console.ReadLine();
                Console.Write("Новый район (Enter - не менять): ");
                string district = Console.ReadLine();
                Console.Write("Новый котик (Enter - не менять): ");
                string drug = Console.ReadLine();

                DrugBuyerDto dto = new DrugBuyerDto
                {
                    Id = id,
                    Name = name,
                    District = district,
                    FavouriteDrug = drug
                };
                UpdateBuyerRequested?.Invoke(this, new DrugBuyerEventArgs(dto));
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }

        private void ShowAllClients()
        {
            AllBuyersRequested?.Invoke(this, EventArgs.Empty);
        }

        private void GetDistrictStatistics()
        {
            StatisticsRequested?.Invoke(this, EventArgs.Empty);
        }

        private void GroupByFavouriteDrug()
        {
            Console.Write("Введите название наркотика: ");
            string drug = Console.ReadLine();

            DrugBuyerDto dto = new DrugBuyerDto { FavouriteDrug = drug };
            BuyersByDrugRequested?.Invoke(this, new DrugBuyerEventArgs(dto));
        }

        private void Continue()
        {
            Console.WriteLine("Для продолжения нажмите любую кнопку");
            Console.ReadKey();
        }
    }
}
