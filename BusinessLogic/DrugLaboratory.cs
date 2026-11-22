using DataAccessLayer;
using Model;
using Shared;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class DrugLaboratory : IDrugLaboratory
    {
        private readonly IRepository<DrugBuyer> _repository;
        private readonly DrugStatisticsService _statisticsService;

        public event EventHandler<DrugBuyerEventArgs> BuyerAdded;
        public event EventHandler<DrugBuyerEventArgs> BuyerRemoved;
        public event EventHandler<DrugBuyerEventArgs> BuyerUpdated;

        public DrugLaboratory(IRepository<DrugBuyer> repository, DrugStatisticsService statisticsService)
        {
            _repository = repository;
            _statisticsService = statisticsService;
        }

        /// <summary> Добавить нового покупателя </summary>
        /// <param name="name"> Имя</param>
        /// <param name="district"> Район</param>
        /// <param name="drug"> Котик</param>
        public void AddNewBuyer(string name, string district, string drug)
        {
            DrugBuyer drugBuyer = new DrugBuyer()
            {
                Id = 0,
                Name = name,
                District = district,
                FavouriteDrug = drug
            };

            _repository.Add(drugBuyer);

            BuyerAdded?.Invoke(this, new DrugBuyerEventArgs(ToDto(drugBuyer)));
        }

        /// <summary> Находит покупателя по ID </summary>
        /// <param name="id"> id</param>
        /// <returns> Возвращает покупателя с нужным ID </returns>
        public DrugBuyerDto FindBuyerById(int id)
        {
            return ToDto(_repository.ReadById(id));
        }

        /// <summary> Убирает покупателя из списка по Id </summary>
        /// <param name="id"> Id покупателя </param>
        /// <returns> true, если покупатель найден и удалён; иначе false </returns>
        public bool RemoveBuyer(int id)
        {
            DrugBuyer buyer = _repository.ReadById(id);
            if (buyer == null)
                return false;

            _repository.Delete(id);
            BuyerRemoved?.Invoke(this, new DrugBuyerEventArgs(ToDto(buyer)));
            return true;
        }

        /// <summary> Получает список всех покупателей </summary>
        /// <returns> Возвращает список всех покупателей </returns>
        public List<DrugBuyerDto> GetAllBuyers()
        {
            List<DrugBuyerDto> tempList = new List<DrugBuyerDto>();

            foreach (DrugBuyer drugBuyer in _repository.ReadAll())
            {
                tempList.Add(ToDto(drugBuyer));
            }

            return tempList;
        }

        /// <summary> Обновляет данные покупателя</summary>
        /// <param name="name"> Имя </param>
        /// <param name="district"> Район </param>
        /// <param name="favouriteDrug"> Любимый котик </param>
        /// <param name="id"> id </param>
        public void ChangeBuyer(string name, string district, string favouriteDrug, int id)
        {
            DrugBuyer buyer = _repository.ReadById(id);

            if (buyer != null)
            {
                buyer.ChangeName(name);
                buyer.ChangeDistrict(district);
                buyer.ChangeFavouriteDrug(favouriteDrug);
                _repository.Update(buyer);
                BuyerUpdated?.Invoke(this, new DrugBuyerEventArgs(ToDto(buyer)));
            }
        }

        /// <summary> Получает статистику по районам и их популярности </summary>
        /// <returns> Возвращает словарь в котором ключ - район, а значение - словарь,
        /// в котором ключ - котик, а значение - количество появлений</returns>
        public Dictionary<string, Dictionary<string, int>> GetDistrictStatistics()
        {
            return _statisticsService.GetDistrictStatistics();
        }

        /// <summary> Получает список покупателей по их любимому котику </summary>
        /// <param name="drug"> Любимый котик </param>
        /// <returns> Возвращает список покупателей по их любимому котику </returns>
        public List<DrugBuyerDto> GetBuyersByDrug(string drug)
        {
            List<DrugBuyerDto> result = new List<DrugBuyerDto>();

            foreach (DrugBuyer drugBuyer in _statisticsService.GetBuyersByDrug(drug))
            {
                result.Add(ToDto(drugBuyer));
            }

            return result;
        }

        /// <summary> Получает список уникальных котиков </summary>
        /// <returns> Возвращает список строк с уникальными котиками </returns>
        public List<string> GetUniqueDrugs()
        {
            return _statisticsService.GetUniqueDrugs();
        }

        private static DrugBuyerDto ToDto(DrugBuyer buyer)
        {
            if (buyer == null)
                return null;

            return new DrugBuyerDto
            {
                Id = buyer.Id,
                Name = buyer.Name,
                District = buyer.District,
                FavouriteDrug = buyer.FavouriteDrug
            };
        }
    }
}
