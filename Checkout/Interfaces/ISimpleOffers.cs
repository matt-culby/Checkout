using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public interface ISimpleOffers
    {
        void ApplyOffer(Item item, string discountedItem);
    }
}
