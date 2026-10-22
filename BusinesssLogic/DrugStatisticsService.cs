using DataAccessLayer;
using Model;
using System.Collections.Generic;

namespace BusinesssLogic
{
    public class DrugStatisticsService
    {
        private readonly IRepository<DrugBuyer> _repository;

        public DrugStatisticsService(IRepository<DrugBuyer> repository)
        {
            _repository = repository;
        }

        /// <summary> Получает список уникальных котиков </summary>
        /// <returns> Возвращает список строк с уникальными котиками </returns>
        public List<string> GetUniqueDrugs()
        {
            List<string> result = new List<string>();

            foreach (DrugBuyer buyer in _repository.ReadAll())
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

            foreach (DrugBuyer buyer in _repository.ReadAll())
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

            foreach (DrugBuyer buyer in _repository.ReadAll())
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
    }
}
