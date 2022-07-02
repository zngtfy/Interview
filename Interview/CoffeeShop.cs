namespace Interview
{
    public class CoffeeShop
    {
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
                cost = 2.0;
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
    }

    public class CoffeeOrder
    {
        public BeanType BeanType { get; set; }
        public bool IsDoubleShot { get; set; }
        public bool HasMilk { get; set; }
        public CoffeeSize Size { get; set; }
    }

    public enum BeanType
    {
        Vietnamese,
        Jamaican
    }

    public enum CoffeeSize
    {
        Medium,
        Large
    }
}
