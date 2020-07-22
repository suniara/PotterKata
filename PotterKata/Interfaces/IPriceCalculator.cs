using System.Collections.Generic;

namespace PotterKata.Interfaces
{
    public interface IPriceCalculator
    {
        decimal GetLowestPrice(List<List<int[]>> allCombinations);
    }
}
