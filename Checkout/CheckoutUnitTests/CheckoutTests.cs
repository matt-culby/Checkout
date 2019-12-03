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

        [TestMethod]
        public void AddListOfItemsAndCheckBuyOneGetOne()
        {
            decimal orderTotal;

            List<string> itemNames = new List<string>
            {
                "Apple",
                "Apple",
                "Orange"
            };

            _pointOfSale.ScanItemsWithDiscountCheck(itemNames, DiscountType.BuyOneGetOne, "Apple");

            orderTotal = _pointOfSale.TotalOrder();

            Assert.AreEqual(.85M, orderTotal);
        }

        [TestMethod]
        public void AddListOfItemsAndCheckThreeForTwo()
        {
            decimal orderTotal;

            List<string> itemNames = new List<string>
            {
                "Orange",
                "Apple",
                "Orange",
                "Orange"
            };

            _pointOfSale.ScanItemsWithDiscountCheck(itemNames, DiscountType.ThreeForTwo, "Orange");

            orderTotal = _pointOfSale.TotalOrder();

            Assert.AreEqual(1.1M, orderTotal);
        }

        [TestMethod]
        public void AddListOfItemsAndCheckBuyOneGetOneMany()
        {
            decimal orderTotal;

            List<string> itemNames = new List<string>
            {
                "Apple",
                "Apple",
                "Orange",
                "Orange",
                "Apple",
                "Apple"
            };

            _pointOfSale.ScanItemsWithDiscountCheck(itemNames, DiscountType.BuyOneGetOne, "Apple");

            orderTotal = _pointOfSale.TotalOrder();

            Assert.AreEqual(1.7M, orderTotal);
        }

        [TestMethod]
        public void AddListOfItemsAndCheckThreeForTwoMany()
        {
            decimal orderTotal;

            List<string> itemNames = new List<string>
            {
                "Orange",
                "Apple",
                "Orange",
                "Orange",
                "Orange",
                "Orange",
                "Orange",
                "Apple"
            };

            _pointOfSale.ScanItemsWithDiscountCheck(itemNames, DiscountType.ThreeForTwo, "Orange");

            orderTotal = _pointOfSale.TotalOrder();

            Assert.AreEqual(2.2M, orderTotal);
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
