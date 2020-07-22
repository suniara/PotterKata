using Microsoft.Extensions.DependencyInjection;
using PotterKata.Interfaces;
using PotterKata.Service;
using System;
using System.Collections.Generic;

namespace PotterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<ConsoleApplication>().Run();
        }


        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPriceCalculator, PriceCalculator>();
            services.AddSingleton<IBasketHelper, BasketHelper>();
            services.AddSingleton<IBasketSplitter, BasketSplitter>();
            
            services.AddTransient<ConsoleApplication>();
            return services;
        }
    }


    public class ConsoleApplication
    {
        private readonly IPriceCalculator _priceCalculator;
        private readonly IBasketHelper _basketHelper;
        private readonly IBasketSplitter _basketSplitter;

        public ConsoleApplication(IPriceCalculator priceCalculator, IBasketHelper basketHelper, IBasketSplitter basketSplitter)
        {
            _priceCalculator = priceCalculator;
            _basketHelper = basketHelper;
            _basketSplitter = basketSplitter;
        }

        // Application starting point
        public void Run()
        {
            try
            {
                var lowestTotalPrice = GetPrice(new List<int>() { 1, 1, 2, 2, 3, 3, 4, 5 }, 5);
                Console.WriteLine($"The price of the basket is : £{ string.Format("{0:0.00}", Math.Round(lowestTotalPrice, 2)) }");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private decimal GetPrice(List<int> basket, int numberOfBooksInSeries)
        {
            // group identical items in basket
            var groupedBasket = _basketHelper.GetBasketAggregation(basket, numberOfBooksInSeries);
            // get all combinations for consideration
            var allCombos = _basketSplitter.GetBasketCombinations(groupedBasket, numberOfBooksInSeries);
            // return the lowest price
            return _priceCalculator.GetLowestPrice(allCombos);
        }
    }
}
