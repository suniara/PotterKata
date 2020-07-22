using PotterKata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterKata.Service
{
    public class BasketHelper : IBasketHelper
    {
        List<int[]> Results = new List<int[]>();

        public int[] GetBasketAggregation(List<int> basketItems, int numberOfBooksInSeries)
        {
            if (basketItems.Any(x => x > numberOfBooksInSeries)) throw new Exception("Invalid item in basket");

            int[] items = new int[numberOfBooksInSeries];

            foreach (var basketItem in basketItems)
            {
                items[basketItem - 1]++;
            }
            return items;
        }

        public List<int[]> GetCombinations(int[] basketItems, int bookCombinationNumber)
        {
            int[] modifiedBasket = basketItems;
            int[] newBasketCombo = new int[basketItems.Length];
            if (basketItems.Count(x => x >= 1) >= bookCombinationNumber)
            {
                // We have a combination in the basket for the bookCombinationNumber
                int bookcounter = bookCombinationNumber;
                for (int i = 0; i < basketItems.Length; i++)
                {
                    if (bookcounter == 0) break;    // we may have skipped zero book counts below
                    int item = basketItems[i];
                    if (item == 0)
                    {
                        // no books in this category so move on
                        newBasketCombo[i] = 0;
                        continue;
                    }
                    bookcounter--;
                    newBasketCombo[i]++;            // update new basket subset
                    modifiedBasket[i] = --item;     // update the modified basket
                }
                
                // Add the new basket subset to Results as it's a possible low combination
                if (!newBasketCombo.All(x => x == 0))
                    Results.Add(newBasketCombo);

                // check the modified basket again for more combinations of bookCombinationNumber
                this.GetCombinations(modifiedBasket, bookCombinationNumber);
            }
            else
            {
                // None found, let's add the last modified 
                // basket (may be the original contents if no combination found)
                // as long as the basket consists of 1's and 0's
                if (!modifiedBasket.All(x=> x == 0) && !modifiedBasket.Any(x=> x > 1))
                    Results.Add(modifiedBasket);
            }

            // make sure we have something in the basket
            if (!Results.Any())
                Results.Add(basketItems);

            return Results;
        }
    }
}
