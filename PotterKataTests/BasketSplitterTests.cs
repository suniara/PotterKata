using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterKata.Interfaces;
using PotterKata.Service;
using System;

namespace PotterKataTests
{
    [TestClass]
    public class BasketSplitterTests
    {
        IBasketSplitter _basketSplitter;
        IBasketHelper _basketHelper;

        [TestInitialize]
        public void Setup()
        {
            _basketHelper = new BasketHelper();
            _basketSplitter = new BasketSplitter(_basketHelper);
        }

        [TestMethod]
        public void GetBasketCombinations_WhenCalledWithInvalidBasket_ThrowsException()
        {
            int booksInSeries = 4;
            int[] basketItems = new int[] { 2, 2, 2, 1, 1 };

            Assert.ThrowsException<Exception>(() => _basketSplitter.GetBasketCombinations(basketItems, booksInSeries));
        }

        [TestMethod]
        public void GetBasketCombinations_WhenCalledWithValidBasket_ReturnsCorrectCombinationsSimple()
        {
            int booksInSeries = 5;
            int[] basketItems = new int[] { 1, 1, 1, 1, 1 };

            var combos = _basketSplitter.GetBasketCombinations(basketItems, booksInSeries);

            Assert.AreEqual(5, combos.Count);
        }

        [TestMethod]
        public void GetBasketCombinations_WhenCalledWithValidBasket_ReturnsCorrectCombinationsComplex()
        {
            int booksInSeries = 5;
            int[] basketItems = new int[] { 2, 2, 2, 1, 1 };

            var combos = _basketSplitter.GetBasketCombinations(basketItems, booksInSeries);

            Assert.AreEqual(5, combos.Count);
        }
    }
}
