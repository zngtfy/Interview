namespace WebApplication.DAL.Models
{
    public class CoffeeOrder
    {
        public BeanType BeanType { get; set; }
        public bool IsDoubleShot { get; set; }
        public bool HasMilk { get; set; }
        public CoffeeSize Size { get; set; }
    }
}
