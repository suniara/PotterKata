using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterKata.Interfaces;
using PotterKata.Service;
using System;
using System.Collections.Generic;

namespace PotterKataTests
{
    [TestClass]
    public class BasketHelperTests
    {
        IBasketHelper _basketHelper;

        [TestInitialize]
        public void Setup()
        {
            _basketHelper = new BasketHelper();
        }

        [TestMethod]
        public void GetBasketAggregation_WhenCalledWithInvalidBasketItem_ThrowsException()
        {
            var basketItems = new List<int>() { 1, 2, 6 };
            var booksInSeries = 5;

            Assert.ThrowsException<Exception>(() => _basketHelper.GetBasketAggregation(basketItems, booksInSeries));
        }
        [TestMethod]
        public void GetBasketAggregation_WhenCalledWithValidBasketItems_ReturnsIntArray()
        {
            var basketItems = new List<int>() { 1, 2, 5 };
            var booksInSeries = 5;

            var intArray = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);

            Assert.IsInstanceOfType(intArray, typeof(int[]));
        }

        [TestMethod]
        public void GetBasketAggregation_WhenCalledWithValidBasketItems_ReturnsCorrectArrayLength()
        {
            var basketItems = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 5 };
            var booksInSeries = 9;

            var intArray = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);

            Assert.AreEqual(intArray.Length, booksInSeries);
        }

        [TestMethod]
        public void GetBasketAggregation_WhenCalledWithValidBasketItems_ReturnsValidArray()
        {
            var basketItems = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 5 };
            var booksInSeries = 5;
            var expectedValue = new int[5] { 2, 2, 2, 1, 1 };
            
            var intArray = _basketHelper.GetBasketAggregation(basketItems, booksInSeries);

            Assert.AreEqual(intArray.Length, expectedValue.Length);
            for (int i = 0; i < expectedValue.Length; i++)
            {
                Assert.AreEqual(intArray[i], expectedValue[i]);
            }
        }

        [TestMethod]
        public void GetCombinations_WhenCalledWithCombination5_IsValid()
        {
            int[] basketItems = new int[] { 2, 2, 2, 1, 1 };
            int bookCombinationNumber = 5;

            var results = _basketHelper.GetCombinations(basketItems, bookCombinationNumber);

            Assert.AreEqual(2, results.Count);
        }

        [TestMethod]
        public void GetCombinations_WhenCalledWithCombination4_IsValid()
        {
            int[] basketItems = new int[] { 2, 2, 2, 1, 1 };
            int bookCombinationNumber = 4;

            var results = _basketHelper.GetCombinations(basketItems, bookCombinationNumber);

            Assert.AreEqual(2, results.Count);
        }

        [TestMethod]
        public void GetCombinations_WhenCalledWithCombination3_IsValid()
        {
            int[] basketItems = new int[] { 2, 2, 2, 1, 1 };
            int bookCombinationNumber = 3;

            var results = _basketHelper.GetCombinations(basketItems, bookCombinationNumber);

            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void GetCombinations_WhenCalledWithCombination2_IsValid()
        {
            int[] basketItems = new int[] { 2, 2, 2, 1, 1 };
            int bookCombinationNumber = 2;

            var results = _basketHelper.GetCombinations(basketItems, bookCombinationNumber);

            Assert.AreEqual(4, results.Count);
        }

        [TestMethod]
        public void GetCombinations_WhenCalledWithCombination1_IsValid()
        {
            int[] basketItems = new int[] { 2, 2, 2, 1, 1 };
            int bookCombinationNumber = 1;

            var results = _basketHelper.GetCombinations(basketItems, bookCombinationNumber);

            Assert.AreEqual(8, results.Count);
        }
    }
}
