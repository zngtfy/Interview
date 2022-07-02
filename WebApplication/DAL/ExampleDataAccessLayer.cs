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

        public IEnumerable<CoffeeType> GetCoffeeTypeByContryName(string contruyName)
        {
            return _context.CoffeeTypes.Where(ct => ct.CountryOfOrigin == contruyName);
        }

        public decimal GetCoffeePriceByCountry(string contruyName)
        {
            var price = _context.CoffeeTypes.Where(ct => ct.CountryOfOrigin == contruyName).Select(p => p.Price).FirstOrDefault();
            return price;
        }

        public IList<CoffeeType> SearchCoffeeTypeByContryName(int userId, string countryName)
        {
            var types = GetAllCoffeeTypes()
                .Where(ct => ct.CountryOfOrigin == countryName)
                .ToList().AsReadOnly();

            var coffeePreference = _context.UserCoffeePreferences
                .SingleOrDefault(preference => preference.UserId == userId && preference.ContryName == countryName);
            if (coffeePreference != null)
            {
                coffeePreference.CoffeeSearch++;
                _context.SaveChanges();
            }
            return types;
        }

        public void IncreasePrices(IEnumerable<CoffeeType> coffeeTypes, double percentage)
        {
            foreach (var coffeeType in coffeeTypes)
            {
                var type = _context.CoffeeTypes.Single(ct => ct.CoffeeTypeId == coffeeType.CoffeeTypeId);
                type.Price *= 1 + (decimal)percentage;
            }

            var max = double.MaxValue;
            var maxd = decimal.MaxValue;

            // batch
            _context.SaveChanges();
        }

        private IQueryable<CoffeeType> GetAllCoffeeTypes()
        {
            return _context.CoffeeTypes;
        }
    }
}
