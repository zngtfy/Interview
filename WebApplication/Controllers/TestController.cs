using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication.DAL;
using WebApplication.DAL.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        public TestController(ShopContext db)
        {
            _dal = new ExampleDataAccessLayer(db);
            _db = db;
        }

        [HttpGet("CreateSampleData")]
        public IActionResult CreateSampleData()
        {
            if (_db.Users.Count() == 0)
            {
                _db.Users.Add(new User());
                _db.Users.Add(new User());
                _db.Users.Add(new User());
            }

            if (_db.CoffeeTypes.Count() == 0)
            {
                _db.CoffeeTypes.Add(new CoffeeType { CountryOfOrigin = "Vietnam", Price = 1 });
                _db.CoffeeTypes.Add(new CoffeeType { CountryOfOrigin = "America", Price = 2 });
                _db.CoffeeTypes.Add(new CoffeeType { CountryOfOrigin = "Australia", Price = 3 });
                _db.CoffeeTypes.Add(new CoffeeType { CountryOfOrigin = "Laos", Price = 4 });
            }

            _db.SaveChanges();
            return Ok();
        }

        [HttpGet("SearchAustralianCoffeeTypes")]
        public IActionResult SearchAustralianCoffeeTypes()
        {
            var user = new User { UserId = 1 };
            //user = null;
            var res = _dal.SearchAustralianCoffeeTypes(user);
            return Ok(res);
        }

        [HttpGet("IncreasePrices1")]
        public async Task<IActionResult> IncreasePrices1(int price)
        {
            List<CoffeeType> coffeeTypes = null;
            Thread.Sleep(1000);
            _dal.IncreasePrices(coffeeTypes, price);
            return Ok(Task.FromResult("ok"));
        }

        [HttpGet("IncreasePrices2")]
        public async Task<IActionResult> IncreasePrices2(int price)
        {
            List<CoffeeType> coffeeTypes = null;
            Thread.Sleep(2000);
            _dal.IncreasePrices(coffeeTypes, price);
            return Ok(Task.FromResult("ok"));
        }

        [HttpGet("IncreasePrices3")]
        public async Task<IActionResult> IncreasePrices3(int price)
        {
            List<CoffeeType> coffeeTypes = null;
            Thread.Sleep(3000);
            _dal.IncreasePrices(coffeeTypes, price);
            return Ok(Task.FromResult("ok"));
        }

        [HttpGet("GetAmericanCoffeePrice")]
        public IActionResult GetAmericanCoffeePrice()
        {
            var res = _dal.GetAmericanCoffeePrice();
            return Ok(res);
        }

        [HttpGet("GetVietnameseCoffeeTypes")]
        public IActionResult GetVietnameseCoffeeTypes()
        {
            var res = _dal.GetVietnameseCoffeeTypes();
            return Ok(res);
        }

        private ExampleDataAccessLayer _dal;

        private ShopContext _db;
    }
}
