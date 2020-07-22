using PotterKata.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Service
{
    public class PriceCalculator : IPriceCalculator
    {
        public decimal[] BookPrice = new decimal[] { 8m, 8m, 8m, 8m, 8m };
        public decimal[] Discounts = new decimal[] { 1m, 0.95m, 0.9m, 0.8m, 0.75m };

        public PriceCalculator()
        {
        }

        public decimal GetLowestPrice(List<List<int[]>> allCombinations)
        {
            List<decimal> totals = new List<decimal>();
            foreach (var combination in allCombinations)
            {
                decimal total = 0m;
                foreach (var item in combination)
                {
                    // get the total + discount for each basket subset
                    total += ApplyDiscount(item);
                }
                totals.Add(total);
            }

            // return the lowest one
            return totals.Min();
        }

        private decimal ApplyDiscount(int[] basketItems)
        {
            int count = basketItems.Count(x => x == 1);
            decimal result = 0m;

            for (int i = 0; i < basketItems.Length; i++)
            {
                if (basketItems[i] == 1)
                {
                    result += BookPrice[i];
                }
            }

            return result * Discounts[count-1];
        }
    }
}
