using Interview.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() { }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CoffeeType> CoffeeTypes { get; set; }
        public virtual DbSet<UserCoffeePreference> UserCoffeePreferences { get; set; }
    }
}
