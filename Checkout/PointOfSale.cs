using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class PointOfSale
    {
        private Dictionary<string, decimal> _prices { get; set; }
        private List<Item> _cart { get; set; }

        public PointOfSale(Dictionary<string, decimal> prices)
        {
            _prices = prices;
            AddItemsToCart();
        }

        public void ScanItem(string itemName)
        {
            var scannedItem = GetItemFromCartByName(itemName);
            scannedItem.Quantity += 1;
        }

        public void ScanList(List<string> itemNames)
        {
            foreach (var itemName in itemNames)
            {
                var scannedItem = GetItemFromCartByName(itemName);
                scannedItem.Quantity += 1;
            }
        }

        public decimal TotalOrder()
        {
            var orderTotal = 0M;

            foreach (var item in _cart)
            {
                orderTotal += item.CalculateTotal();
            }

            return orderTotal;
        }

        public void ScanItemsWithDiscountCheck(List<string> itemNames, DiscountType discountType, string discountedItem)
        {
            foreach (var itemName in itemNames)
            {
                var scannedItem = GetItemFromCartByName(itemName);
                scannedItem.Quantity += 1;
            }

            foreach (var item in _cart)
            {
                CheckDiscount(item, discountType, discountedItem);
            }
        }

        private void CheckDiscount(Item item, DiscountType discountType, string discountedItem)
        {
            switch (discountType)
            {
                case DiscountType.BuyOneGetOne:
                    new BuyOneGetOne().ApplyOffer(item, discountedItem);
                    break;
                case DiscountType.ThreeForTwo:
                    new ThreeForTwo().ApplyOffer(item, discountedItem);
                    break;
                default:
                    break;
            }
        }   

        private void AddItemsToCart()
        {
            _cart = new List<Item>();

            foreach (var price in _prices)
            {
                var item = new Item(price.Key, price.Value);
                _cart.Add(item);
            }
        }

        private Item GetItemFromCartByName(string name)
        {
            return _cart.Where(item => item.GetName() == name).FirstOrDefault();
        }
    }
}
