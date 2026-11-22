using Model;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IDrugLaboratory
    {
        /// <summary> Добавить нового покупателя </summary>
        /// <param name="name"> Имя</param>
        /// <param name="district"> Район</param>
        /// <param name="drug"> Котик</param>
        void AddNewBuyer(string name, string district, string drug);

        /// <summary> Находит покупателя по ID </summary>
        /// <param name="id"> id</param>
        /// <returns> Возвращает покупателя с нужным ID </returns>
        DrugBuyer FindBuyerById(int id);

        /// <summary> Убирает покупателя из списка по Id </summary>
        /// <param name="id"> Id покупателя </param>
        /// <returns> true, если покупатель найден и удалён; иначе false </returns>
        bool RemoveBuyer(int id);

        /// <summary> Получает список всех покупателей </summary>
        /// <returns> Возвращает список всех покупателей </returns>
        List<DrugBuyer> GetAllBuyers();

        /// <summary> Меняет имя на новое</summary>
        /// <param name="name"> Имя </param>
        /// <param name="id"> id </param>
        void ChangeName(string name, int id);

        /// <summary> Меняет район на новый</summary>
        /// <param name="district"> Район</param>
        /// <param name="id"> id </param>
        void ChangeDistrict(string district, int id);

        /// <summary> Меняет любимый наркотик на новый</summary>
        /// <param name="favouriteDrug"> Любимый котик </param>
        /// <param name="id"> id </param>
        void ChangeFavouriteDrug(string favouriteDrug, int id);

        /// <summary> Получает статистику по районам и их популярности </summary>
        /// <returns> Возвращает словарь в котором ключ - район, а значение - словарь,
        /// в котором ключ - котик, а значение - количество появлений</returns>
        Dictionary<string, Dictionary<string, int>> GetDistrictStatistics();

        /// <summary> Получает список покупателей по их любимому котику </summary>
        /// <param name="drug"> Любимый котик </param>
        /// <returns> Возвращает список покупателей по их любимому котику </returns>
        List<DrugBuyer> GetBuyersByDrug(string drug);

        /// <summary> Получает список уникальных котиков </summary>
        /// <returns> Возвращает список строк с уникальными котиками </returns>
        List<string> GetUniqueDrugs();
    }
}
