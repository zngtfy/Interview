using System;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new CoffeeOrder { BeanType = BeanType.Japanese };
            var shop = new CoffeeShop();
            //shop.CalculateCoffeeCost(order);
            shop.CalculateCoffeeCostImprove(order);

            Console.WriteLine("Hello World!");
        }
    }
}
