using System;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new CoffeeOrder();
            var shop = new CoffeeShop();
            shop.CalculateCoffeeCost(order);

            Console.WriteLine("Hello World!");
        }
    }
}
