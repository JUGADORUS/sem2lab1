using BusinessLogic;
using Shared;
using System;

namespace Presenter
{
    public class DrugPresenter
    {
        private readonly IView _view;
        private readonly IDrugLaboratory _model;

        public DrugPresenter(IView view ,IDrugLaboratory model)
        {
            _view = view;
            _model = model;

            _view.AddBuyerRequested += OnAddBuyerRequested;
            _model.BuyerAdded += OnBuyerAdded;

            _view.RemoveBuyerRequested += OnRemoveBuyerRequested;
            _model.BuyerRemoved += OnBuyerRemoved;

            _view.UpdateBuyerRequested += OnUpdateBuyerRequested;
            _model.BuyerUpdated += OnBuyerUpdated;

            _view.AllBuyersRequested += OnAllBuyersRequested;
            _view.BuyersByDrugRequested += OnBuyersByDrugRequested;
            _view.StatisticsRequested += OnStatisticsRequested;
        }

        private void OnAddBuyerRequested(object sender, DrugBuyerEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Buyer.Name) || string.IsNullOrWhiteSpace(e.Buyer.District) || string.IsNullOrWhiteSpace(e.Buyer.FavouriteDrug))
            {
                _view.ShowMessage("Заполните все поля");
                return;
            }

            _model.AddNewBuyer(e.Buyer.Name, e.Buyer.District, e.Buyer.FavouriteDrug);
        }

        private void OnBuyerAdded(object sender, DrugBuyerEventArgs e)
        {
            _view.ShowMessage("Новый покупатель успешно добавлен");
            RefreshAll();
        }

        private void OnRemoveBuyerRequested(object sender, DrugBuyerEventArgs e)
        {
            if (!_model.RemoveBuyer(e.Buyer.Id))
            {
                _view.ShowMessage("Покупатель с таким ID не найден");
            }
        }

        private void OnBuyerRemoved(object sender, DrugBuyerEventArgs e)
        {
            _view.ShowMessage($"Покупатель {e.Buyer.Name} успешно удалён");
            RefreshAll();
        }

        private void OnUpdateBuyerRequested(object sender, DrugBuyerEventArgs e)
        {
            DrugBuyerDto current = _model.FindBuyerById(e.Buyer.Id);

            if (current == null)
            {
                _view.ShowMessage("Покупатель с таким ID не найден");
                return;
            }

            string name = string.IsNullOrWhiteSpace(e.Buyer.Name) ? current.Name : e.Buyer.Name;
            string district = string.IsNullOrWhiteSpace(e.Buyer.District) ? current.District : e.Buyer.District;
            string drug = string.IsNullOrWhiteSpace(e.Buyer.FavouriteDrug) ? current.FavouriteDrug : e.Buyer.FavouriteDrug;

            if (name == current.Name && district == current.District && drug == current.FavouriteDrug)
            {
                _view.ShowMessage("Введите новые данные для изменения");
                return;
            }

            _model.ChangeBuyer(name, district, drug, current.Id);
        }

        private void OnBuyerUpdated(object sender, DrugBuyerEventArgs e)
        {
            _view.ShowMessage($"Покупатель {e.Buyer.Name} успешно обновлён");
            RefreshAll();
        }

        private void OnAllBuyersRequested(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void OnBuyersByDrugRequested(object sender, DrugBuyerEventArgs e)
        {
            _view.ShowBuyers(_model.GetBuyersByDrug(e.Buyer.FavouriteDrug));
        }

        private void OnStatisticsRequested(object sender, EventArgs e)
        {
            _view.ShowStatistics(_model.GetDistrictStatistics());
        }

        private void RefreshAll()
        {
            _view.ShowBuyers(_model.GetAllBuyers());
            _view.ShowDrugs(_model.GetUniqueDrugs());
        }
    }
}
