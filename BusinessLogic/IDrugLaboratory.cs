using Model;
using System;
using System.Collections.Generic;
using Shared;

namespace BusinessLogic
{
    public interface IDrugLaboratory
    {
        /// <summary> Добавить нового покупателя </summary>
        /// <param name="name"> Имя</param>
        /// <param name="district"> Район</param>
        /// <param name="drug"> Котик</param>
        void AddNewBuyer(string name, string district, string drug);

        /// <summary> Уведомляет, что покупатель добавлен </summary>
        event EventHandler<DrugBuyerEventArgs> BuyerAdded;

        /// <summary> Находит покупателя по ID </summary>
        /// <param name="id"> id</param>
        /// <returns> Возвращает покупателя с нужным ID </returns>
        DrugBuyerDto FindBuyerById(int id);

        /// <summary> Убирает покупателя из списка по Id </summary>
        /// <param name="id"> Id покупателя </param>
        /// <returns> true, если покупатель найден и удалён; иначе false </returns>
        bool RemoveBuyer(int id);

        /// <summary> Уведомляет, что покупатель удален </summary>
        event EventHandler<DrugBuyerEventArgs> BuyerRemoved;

        /// <summary> Получает список всех покупателей </summary>
        /// <returns> Возвращает список всех покупателей </returns>
        List<DrugBuyerDto> GetAllBuyers();

        /// <summary> Обновляет данные покупателя</summary>
        /// <param name="name"> Имя </param>
        /// <param name="district"> Район </param>
        /// <param name="favouriteDrug"> Любимый котик </param>
        /// <param name="id"> id </param>
        void ChangeBuyer(string name, string district, string favouriteDrug, int id);

        /// <summary> Уведомляет, что покупатель обновлен </summary>
        event EventHandler<DrugBuyerEventArgs> BuyerUpdated;

        /// <summary> Получает статистику по районам и их популярности </summary>
        /// <returns> Возвращает словарь в котором ключ - район, а значение - словарь,
        /// в котором ключ - котик, а значение - количество появлений</returns>
        Dictionary<string, Dictionary<string, int>> GetDistrictStatistics();

        /// <summary> Получает список покупателей по их любимому котику </summary>
        /// <param name="drug"> Любимый котик </param>
        /// <returns> Возвращает список покупателей по их любимому котику </returns>
        List<DrugBuyerDto> GetBuyersByDrug(string drug);

        /// <summary> Получает список уникальных котиков </summary>
        /// <returns> Возвращает список строк с уникальными котиками </returns>
        List<string> GetUniqueDrugs();
    }
}
