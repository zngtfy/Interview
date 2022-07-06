using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication.DAL.Models;

namespace WebApplication.DAL
{
    public class ExampleDataAccessLayer
    {
        private readonly ShopContext _context;

        public ExampleDataAccessLayer(ShopContext context)
        {
            _context = context;
        }

        public IEnumerable<CoffeeType> GetVietnameseCoffeeTypes()
        {
            return _context.CoffeeTypes.Where(ct => ct.CountryOfOrigin == "Vietnam");
        }

        public decimal GetAmericanCoffeePrice()
        {
            var americanCoffees = _context.CoffeeTypes.Where(ct => ct.CountryOfOrigin == "America").ToList();
            return americanCoffees[0].Price;
        }

        public IEnumerable<CoffeeType> SearchAustralianCoffeeTypes(User user)
        {
            var types = GetAllCoffeeTypes()
                .Where(ct => ct.CountryOfOrigin == "Australia")
                .ToList()
                .AsReadOnly();

            var u = _context.UserCoffeePreferences.SingleOrDefault(preference => preference.UserId == user.UserId);
            u.AustralianCoffeeSearch++;
            _context.SaveChanges();
            return types;
        }

        public void IncreasePrices(IEnumerable<CoffeeType> coffeeTypes, decimal percentage)
        {
            var sql = "UPDATE [dbo].[CoffeeTypes] SET Price = Price + 1;";
            _context.Database.ExecuteSqlRaw(sql);
            return;

            //coffeeTypes = _context.CoffeeTypes.ToList();
            foreach (var coffeeType in coffeeTypes)
            {
                var type = _context.CoffeeTypes.Single(ct => ct.CoffeeTypeId == coffeeType.CoffeeTypeId);
                type.Price += percentage;
            }
            _context.SaveChanges();
        }

        private IEnumerable<CoffeeType> GetAllCoffeeTypes()
        {
            return _context.CoffeeTypes.ToList();
        }
    }
}
