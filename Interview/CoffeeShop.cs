﻿using Interview.DAL.Models;
using System.Collections.Generic;

namespace Interview
{
    /// <summary>
    /// What are some issues with the following code sample?
    /// What can be done to improve it?
    ///
    /// If the coffee shop needs to add 10 more bean types,
    /// how would you implement it?
    ///
    /// What would happen as more and more coffee variations
    /// are added? How can you guarantee that the correct
    /// cost is calculated for all the combinations?
    /// </summary>
    public class CoffeeShop
    {
        public CoffeeShop()
        {
            // Add coefficient here or load from DB for BeanType
            _dicBeanType = new Dictionary<int, double>
            {
                { (int)BeanType.Vietnamese, 2.5 },
                { (int)BeanType.Jamaican, 2.3 },
                { (int)BeanType.Canadian, 2.1 }
            };

            // Add coefficient here or load from DB for CoffeeSize
            _dicCoffeeSize = new Dictionary<int, double>
            {
                { (int)CoffeeSize.Medium, 1.0 },
                { (int)CoffeeSize.Large, 1.5 }
            };
        }

        public double CalculateCoffeeCost(CoffeeOrder order)
        {
            double cost;
            if (order.BeanType == BeanType.Vietnamese)
            {
                cost = 2.5;
            }
            else if (order.BeanType == BeanType.Jamaican)
            {
                cost = 2.3;
            }
            else
            {
                cost = 2.0; // OtherBeanType
            }
            if (order.IsDoubleShot)
            {
                cost *= 1.5;
            }
            if (order.HasMilk)
            {
                cost += 0.5;
            }
            if (order.Size == CoffeeSize.Medium)
            {
                cost += 1;
            }
            else if (order.Size == CoffeeSize.Large)
            {
                cost += 1.5;
            }
            return cost;
        }



        private Dictionary<int, double> _dicBeanType;
        private Dictionary<int, double> _dicCoffeeSize;
    }

    public enum BeanType
    {
        Vietnamese,
        Jamaican,
        Japanese,
        Indian,
        Amercian,
        Canadian
    }

    public enum CoffeeSize
    {
        Medium,
        Large
    }
}
