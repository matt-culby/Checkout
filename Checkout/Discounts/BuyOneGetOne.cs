using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class BuyOneGetOne : ISimpleOffers
    {
        public void ApplyOffer(Item item, string discountedItem)
        {
            if (item.GetName() == discountedItem)
            {
                if (item.Quantity >= 2)
                {
                    if (item.Quantity % 2 == 0)
                    {
                        item.Quantity /= 2;
                    }
                    else
                    {
                        var discountedQuantity = (item.Quantity - item.Quantity % 2) / 2;
                        item.Quantity = discountedQuantity + item.Quantity % 2;
                    }
                }
            }
        }
    }
}
