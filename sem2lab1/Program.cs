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
            const string BusinessOneCommand = "5";
            const string BusinessTwoCommand = "6";

            DrugLaboratory drugLaboratory = new DrugLaboratory();

            Console.WriteLine($"Что вы хотите сделать?\n" +
                $"{AddNewBuyerCommand} - Добавить нового клиента в базу\n" +
                $"{RemoveClientCommand} - Ликвидировать клиента\n" +
                $"{ReadClientInfoCommand} - Пробить клиента по глазу бога\n" +
                $"{ChangeClientInfoCommand} - Внушить клиенту новую информацию\n" +
                $"{BusinessOneCommand} - Бизнес ф1\n" +
                $"{BusinessTwoCommand} - Бизнес ф2");

            string UserInput = Console.ReadLine();
            
            switch(UserInput)
            {
                case AddNewBuyerCommand:
                    AddNewClient(drugLaboratory);
                    return;

                case RemoveClientCommand:
                    RemoveClient(drugLaboratory);
                    return;   

                case ReadClientInfoCommand:
                    ReadClientInfo(drugLaboratory);
                    return;

                case ChangeClientInfoCommand: 
                    return;

                case BusinessOneCommand: 
                    return;

                case BusinessTwoCommand: 
                    return;

                default:
                    Console.WriteLine("Неверный ввод");
                    return;
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

            for(int i = 0; i < drugBuyers.Count; i++)
            {
                Console.WriteLine($"{i} - {drugBuyers[i].Name}, район - {drugBuyers[i].District}, любимый котик - {drugBuyers[i].FavouriteDrug}");
            }

            if(int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < drugBuyers.Count)
            {
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

            for (int i = 0; i < drugBuyers.Count; i++)
            {
                Console.WriteLine($"{i} - {drugBuyers[i].Name}");
            }

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < drugBuyers.Count)
            {
                Console.WriteLine($"{index} - {drugBuyers[index].Name}, район - {drugBuyers[index].District}, любимый котик - {drugBuyers[index].FavouriteDrug}");
            }
            else
            {
                Console.WriteLine("Неверный ввод");
            }
        }
    }
}
