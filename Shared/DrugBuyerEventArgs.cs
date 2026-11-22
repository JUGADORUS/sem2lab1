using System;

namespace Shared
{
    public class DrugBuyerEventArgs : EventArgs
    {
        public DrugBuyerDto Buyer { get; set; }

        public DrugBuyerEventArgs(DrugBuyerDto buyer)
        {
            Buyer = buyer;
        }
    }
}
