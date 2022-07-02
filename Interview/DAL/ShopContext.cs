using Interview.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CoffeeType> CoffeeTypes { get; set; }
        public virtual DbSet<UserCoffeePreference> UserCoffeePreferences { get; set; }
    }
}
