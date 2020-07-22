using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterKata.Interfaces;
using PotterKata.Service;
using System.Collections.Generic;

namespace PotterKataTests
{
    [TestClass]
    public class PriceCalculatorTests
    {
        IBasketHelper _basketHelper;
        IBasketSplitter _basketSplitter;
        IPriceCalculator _priceCalculator;

        [TestInitialize]
        public void Setup()
        {
            _basketHelper = new BasketHelper();
            _basketSplitter = new BasketSplitter(_basketHelper);
            _priceCalculator = new PriceCalculator();
        }

        [TestMethod]
        public void GetLowestPrice_WhenCalledWithBasketCombinationsMultiple1_ReturnsCorrectPrice()
        {
            var basketItems = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 5 };
            var booksInSeries = 5;

            var groupedBasket = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);
            var allCombos = _basketSplitter.GetBasketCombinations(groupedBasket, booksInSeries);
            var price = _priceCalculator.GetLowestPrice(allCombos);

            Assert.AreEqual(51.2m, price);
        }

        [TestMethod]
        public void GetLowestPrice_WhenCalledWithBasketCombinationsMultiple2_ReturnsCorrectPrice()
        {
            var basketItems = new List<int>() { 1, 1, 2 };
            var booksInSeries = 5;

            var groupedBasket = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);
            var allCombos = _basketSplitter.GetBasketCombinations(groupedBasket, booksInSeries);
            var price = _priceCalculator.GetLowestPrice(allCombos);

            Assert.AreEqual(23.2m, price);
        }

        [TestMethod]
        public void GetLowestPrice_WhenCalledWithBasketCombinationsMultiple3_ReturnsCorrectPrice()
        {
            var basketItems = new List<int>() { 1, 1, 2, 2 };
            var booksInSeries = 5;

            var groupedBasket = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);
            var allCombos = _basketSplitter.GetBasketCombinations(groupedBasket, booksInSeries);
            var price = _priceCalculator.GetLowestPrice(allCombos);

            Assert.AreEqual(30.4m, price);
        }

        [TestMethod]
        public void GetLowestPrice_WhenCalledWithBasketCombinationsMultiple4_ReturnsCorrectPrice()
        {
            var basketItems = new List<int>() { 1, 1, 2, 3, 3, 4};
            var booksInSeries = 5;

            var groupedBasket = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);
            var allCombos = _basketSplitter.GetBasketCombinations(groupedBasket, booksInSeries);
            var price = _priceCalculator.GetLowestPrice(allCombos);

            Assert.AreEqual(40.8m, price);
        }

        [TestMethod]
        public void GetLowestPrice_WhenCalledWithBasketCombinationsMultiple5_ReturnsCorrectPrice()
        {
            var basketItems = new List<int>() { 1, 2, 2, 3, 4, 5 };
            var booksInSeries = 5;

            var groupedBasket = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);
            var allCombos = _basketSplitter.GetBasketCombinations(groupedBasket, booksInSeries);
            var price = _priceCalculator.GetLowestPrice(allCombos);

            Assert.AreEqual(38m, price);
        }


        [TestMethod]
        public void GetLowestPrice_WhenCalledWithBasketCombinationsComplex1_ReturnsCorrectPrice()
        {
            var basketItems = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 5 };
            var booksInSeries = 5;

            var groupedBasket = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);
            var allCombos = _basketSplitter.GetBasketCombinations(groupedBasket, booksInSeries);
            var price = _priceCalculator.GetLowestPrice(allCombos);

            Assert.AreEqual(51.2m, price);
        }

        // This test highlights an issue with the code, specifically in _basketSplitter.GetBasketCombinations
        [TestMethod]
        public void GetLowestPrice_WhenCalledWithBasketCombinationsComplex2_ReturnsCorrectPrice()
        {
            var basketItems = new List<int>() {  1, 1, 1, 1, 1,
                                                2, 2, 2, 2, 2,
                                                3, 3, 3, 3,
                                                4, 4, 4, 4, 4,
                                                5, 5, 5, 5};
            var booksInSeries = 5;

            var groupedBasket = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);
            var allCombos = _basketSplitter.GetBasketCombinations(groupedBasket, booksInSeries);
            var price = _priceCalculator.GetLowestPrice(allCombos);

            Assert.AreEqual(141.2m, price);
        }
    }
}
