using System.Collections.Generic;
using System.Linq;
using WebApplication.DAL.Models;

namespace WebApplication.DAL
{
    public class ImproveDataAccessLayer
    {
        private readonly ShopContext _context;

        public ImproveDataAccessLayer(ShopContext context)
        {
            _context = context;
        }

        public IEnumerable<CoffeeType> GetVietnameseCoffeeTypes(string countryName)
        {
            return GetAllCoffeeTypes("Vietnam").ToList();
        }

        public decimal GetAmericanCoffeePrice()
        {
            var americanCoffees = GetAllCoffeeTypes("America").FirstOrDefault();
            return americanCoffees == null ? 0 : americanCoffees.Price;
        }

        public IEnumerable<CoffeeType> SearchAustralianCoffeeTypes(User user)
        {
            var types = GetAllCoffeeTypes("Australia").ToList().AsReadOnly();

            if (user != null)
            {
                var u = _context.UserCoffeePreferences.FirstOrDefault(preference => preference.UserId == user.UserId); // dont use SingleOrDefault coz multiple record same UserId
                if (u == null)
                {
                    _context.UserCoffeePreferences.Add(new UserCoffeePreference { UserId = user.UserId, AustralianCoffeeSearch = 1 });
                }
                if (u != null)
                {
                    u.AustralianCoffeeSearch++;
                }
                _context.SaveChanges();
            }

            return types;
        }

        public void IncreasePrices(IEnumerable<CoffeeType> coffeeTypes, double percentage)
        {

            if (coffeeTypes == null || coffeeTypes.Count() == 0 || percentage == 0)
            {
                return;
            }

            var ids = coffeeTypes.Select(p => p.CoffeeTypeId);
            var l = _context.CoffeeTypes.Where(p => ids.Contains(p.CoffeeTypeId)).ToList();

            if (l.Count == 0)
            {
                return;
            }

            // Update Price
            foreach (var type in l)
            {
                type.Price *= 1 + (decimal)percentage;
            }
            _context.SaveChanges();
        }

        private IQueryable<CoffeeType> GetAllCoffeeTypes(string countryOfOrigin)
        {
            return _context.CoffeeTypes.Where(p => p.CountryOfOrigin == countryOfOrigin);
        }
    }
}
