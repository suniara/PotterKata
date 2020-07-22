using System.Collections.Generic;

namespace PotterKata.Interfaces
{
    public interface IBasketSplitter
    {
        List<List<int[]>> GetBasketCombinations(int[] basketItems, int numberOfBooksInSeries);
    }
}
