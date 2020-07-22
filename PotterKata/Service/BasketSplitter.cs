using PotterKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Service
{
    public class BasketSplitter : IBasketSplitter
    {
        IBasketHelper _basketHelper;

        public BasketSplitter(IBasketHelper basketHelper)
        {
            if (basketHelper == null) throw new ArgumentNullException();

            _basketHelper = basketHelper;
        }

        public List<List<int[]>> GetBasketCombinations(int[] basketItems, int numberOfBooksInSeries)
        {
            if (basketItems.Length != numberOfBooksInSeries) throw new Exception();

            // how many zero's?
            var nonzeroCount = numberOfBooksInSeries - basketItems.Count(x => x == 0);
            
            // this will hold all the basket combinations to consider
            List<List<int[]>> allBasketCombinations = new List<List<int[]>>();
            List<int[]> results = new List<int[]>();

            // get the different groups of combinations
            for (int i = 1; i <= numberOfBooksInSeries; i++)
            {
                int[] originalBasketItems = (int[])basketItems.Clone();
                results.Clear();
                results = _basketHelper.GetCombinations(originalBasketItems, i);

                allBasketCombinations.Add(results.Select(x=> x).ToList());

                // no point looking for (e.g.) combinations of 4 if only 3 in the basket
                if (i == nonzeroCount) break;
            }

            return allBasketCombinations;
        }
    }
}
