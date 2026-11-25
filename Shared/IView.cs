using System;
using System.Collections.Generic;

namespace Shared
{
    public interface IView
    {
        event EventHandler<DrugBuyerEventArgs> AddBuyerRequested;
        event EventHandler<DrugBuyerEventArgs> RemoveBuyerRequested;
        event EventHandler<DrugBuyerEventArgs> UpdateBuyerRequested;
        event EventHandler AllBuyersRequested;
        event EventHandler<DrugBuyerEventArgs> BuyersByDrugRequested;
        event EventHandler StatisticsRequested;

        //event EventHandler<DrugBuyerEventArgs> BuyerRemoved;
        //event EventHandler<DrugBuyerEventArgs> BuyerUpdated;

        void ShowBuyers(List<DrugBuyerDto> buyers);
        void ShowDrugs(List<string> drugs);
        void ShowStatistics(Dictionary<string, Dictionary<string, int>> statistics);
        void ShowMessage(string message);
    }
}
