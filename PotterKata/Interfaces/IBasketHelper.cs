using System.Collections.Generic;

namespace PotterKata.Interfaces
{
    public interface IBasketHelper
    {
        int[] GetBasketAggregation(List<int> basketItems, int numberOfBooksInSeries);

        List<int[]> GetCombinations(int[] basketItems, int bookCombinationNumber);
    }
}
