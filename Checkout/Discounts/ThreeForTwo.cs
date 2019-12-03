using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class ThreeForTwo : ISimpleOffers
    {
        public void ApplyOffer(Item item, string discountedItem)
        {
            if (item.GetName() == discountedItem)
            {
                if (item.Quantity >= 3)
                {
                    if (item.Quantity % 3 == 0)
                    {
                        item.Quantity = (item.Quantity / 3) * 2;
                    }
                    else
                    {
                        item.Quantity -= (item.Quantity / 3);
                    }
                }
            }
        }
    }
}
