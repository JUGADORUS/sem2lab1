using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
