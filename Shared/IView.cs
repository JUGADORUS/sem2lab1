using System;
using System.Collections.Generic;

namespace Shared
{
    public interface IView
    {
        /// <summary> Уведомляет презентер о запросе на добавление нового покупателя. </summary>
        event EventHandler<DrugBuyerEventArgs> AddBuyerRequested;

        /// <summary> Уведомляет презентер о запросе на удаление покупателя. </summary>
        event EventHandler<DrugBuyerEventArgs> RemoveBuyerRequested;

        /// <summary> Уведомляет презентер о запросе на обновление покупателя. </summary>
        event EventHandler<DrugBuyerEventArgs> UpdateBuyerRequested;

        /// <summary> Уведомляет презентер о запросе на получение всех покупателей. </summary>
        event EventHandler AllBuyersRequested;

        /// <summary> Уведомляет презентер о запросе на получение всех покупателей по конкретному наркотику. </summary>
        event EventHandler<DrugBuyerEventArgs> BuyersByDrugRequested;

        /// <summary> Уведомляет презентер о запросе на получение статистики. </summary>
        event EventHandler StatisticsRequested;

        /// <summary> Показывает список покупателей в представлении. </summary>
        /// <param name="buyers"></param>
        void ShowBuyers(List<DrugBuyerDto> buyers);

        /// <summary> Показывает список наркотиков в представлении. </summary>
        /// <param name="drugs"></param>
        void ShowDrugs(List<string> drugs);

        /// <summary> Показывает статистику по районам и их популярности в представлении. </summary>
        /// <param name="statistics"></param>
        void ShowStatistics(Dictionary<string, Dictionary<string, int>> statistics);

        /// <summary> Выводит сообщение в представлении. </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }
}
