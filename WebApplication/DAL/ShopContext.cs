using Microsoft.EntityFrameworkCore;
using WebApplication.DAL.Models;

namespace WebApplication.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() { }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CoffeeType> CoffeeTypes { get; set; }
        public virtual DbSet<UserCoffeePreference> UserCoffeePreferences { get; set; }
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
