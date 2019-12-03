using System;
using System.Collections.Generic;
using Checkout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutTests
{
    [TestClass]
    public class CheckoutTests
    {
        private PointOfSale _pointOfSale;

        [TestInitialize]
        public void InitializeTest()
        {
            _pointOfSale = new PointOfSale(GetPrices());
        }

        [TestMethod]
        public void AddItemToTotal()
        {
            decimal orderTotal;

            _pointOfSale.ScanItem("Apple");

            orderTotal = _pointOfSale.TotalOrder();

            Assert.AreEqual(.6M, orderTotal);

            _pointOfSale.ScanItem("Orange");

            orderTotal = _pointOfSale.TotalOrder();

            Assert.AreEqual(.85M, orderTotal);
        }

        [TestMethod]
        public void AddListOfItems()
        {
            decimal orderTotal;

            List<string> itemNames = new List<string>
            {
                "Apple",
                "Apple",
                "Orange",
                "Apple"
            };

            _pointOfSale.ScanList(itemNames);

            orderTotal = _pointOfSale.TotalOrder();

            Assert.AreEqual(2.05M, orderTotal);
        }

        private Dictionary<string, decimal> GetPrices()
        {
            var prices = new Dictionary<string, decimal>
            {
                {"Apple", .6M },
                {"Orange", .25M }
            };

            return prices;
        }
    }
}
