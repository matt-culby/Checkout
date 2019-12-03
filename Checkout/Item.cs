using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Item
    {
        private readonly string _name;
        private readonly decimal _price;

        public Item(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        internal int Quantity { get; set; }

        public string GetName()
        {
            return _name;
        }

        public decimal GetPrice()
        {
            return _price;
        }

        internal decimal CalculateTotal()
        {
            return Quantity * _price;
        }
    }
}
