using System.Web.Mvc;

namespace WebAsp.Controllers
{
    public class HomeController : Controller
    {
        private ExampleDataAccessLayer _dal;

        private coffeeshopEntities _db;



        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            _dal = new ExampleDataAccessLayer();
            _dal.IncreasePrices(null, 1);
            return View();
        }


    }
}
