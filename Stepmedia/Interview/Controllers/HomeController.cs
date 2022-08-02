using Interview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ITransientService _transientService1;
        ITransientService _transientService2;

        IScopedService _scopedService1;
        IScopedService _scopedService2;

        ISingletonService _singletonService1;
        ISingletonService _singletonService2;

        public HomeController(ILogger<HomeController> logger, ITransientService transientService1,
                      ITransientService transientService2,
                      IScopedService scopedService1,
                      IScopedService scopedService2,
                      ISingletonService singletonService1,
                      ISingletonService singletonService2)
        {
            _logger = logger;

            _transientService1 = transientService1;
            _transientService2 = transientService2;

            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;

            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        private void FindMax(int[] arr, int range1Min, int number = 10)
        {
            if (arr == null || arr.Length == 0)
            {
                return;
            }

            // Tim 10 so lon nhat
            for (var i = 0; i < number; i++)
            {
                for (var j = 0; j < arr.Length; j++)
                {
                    // Bo vi tri da chon
                    if (range1Min <= j && j <= range1Min + i)
                    {
                        continue;
                    }

                    // Swap
                    var a = arr[range1Min + i];
                    var b = arr[j];
                    if (b > a)
                    {
                        arr[range1Min + i] = b;
                        arr[j] = a;
                    }
                }
            }
        }

        private void FindSecond(int[] arr, int range1Min, int range2Min, int number = 10)
        {
            // Tim 10 so lon nhi
            for (var i = 0; i < number; i++)
            {
                for (var j = 0; j < arr.Length; j++)
                {
                    // Bo vi tri da chon
                    if (range2Min <= j && j <= range2Min + i)
                    {
                        continue;
                    }

                    // Bo vi tri da chon so lon nhat
                    if (range1Min <= j && j <= range1Min + number)
                    {
                        continue;
                    }

                    // Swap
                    var a = arr[range2Min + i];
                    var b = arr[j];
                    if (b > a)
                    {
                        arr[range2Min + i] = b;
                        arr[j] = a;
                    }
                }
            }
        }

        private void FindThird(int[] arr, int range1Min, int range2Min, int range3Min, int number = 10)
        {
            // Tim 10 so lon nhi
            for (var i = 0; i < number; i++)
            {
                for (var j = 0; j < arr.Length; j++)
                {
                    // Bo vi tri da chon
                    if (range3Min <= j && j <= range3Min + i)
                    {
                        continue;
                    }

                    // Bo vi tri da chon so lon nhat
                    if (range1Min <= j && j <= range1Min + number)
                    {
                        continue;
                    }

                    // Bo vi tri da chon so lon nhi
                    if (range2Min <= j && j <= range2Min + number)
                    {
                        continue;
                    }

                    // Swap
                    var a = arr[range3Min + i];
                    var b = arr[j];
                    if (b > a)
                    {
                        arr[range3Min + i] = b;
                        arr[j] = a;
                    }
                }
            }
        }


        private string RandNum()
        {
            var rand = new Random();
            var num = rand.Next(30, 100);

            var res = "";
            for (var i = 0; i < num; i++)
            {
                res += rand.Next(0, 100) + ",";
            }

            return res;
        }

        public IActionResult Index()
        {
            var vm = new NumberVm();
            vm.RequestNumber = RandNum();

            ViewBag.message1 = "First Instance " + _transientService1.GetID().ToString();
            ViewBag.message2 = "Second Instance " + _transientService2.GetID().ToString();


            ViewBag.message3 = "First Instance " + _scopedService1.GetID().ToString();
            ViewBag.message4 = "Second Instance " + _scopedService2.GetID().ToString();

            ViewBag.message5 = "First Instance " + _singletonService1.GetID().ToString();
            ViewBag.message6 = "Second Instance " + _singletonService2.GetID().ToString();


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(NumberVm vm)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(vm.RequestNumber))
            {
                vm.Result = "Required";
                return View(vm);
            }

            //vm.RequestNumber = "1,2,3,4,5,6,7,8,9,10,16,24,4,5,6,7,8,9,10,16,24,4,5,6,7,8,9,10,16,24";

            var req = vm.RequestNumber.TrimEnd(',');
            int[] arr;
            try
            {
                arr = req.Split(',').Select(Int32.Parse).ToArray();
            }
            catch
            {
                vm.Result = "Du lieu phai la so";
                return View(vm);
            }

            if (arr == null || arr.Length < 30)
            {
                vm.Result = "Nhap toi thieu 30 so, cac so cach nhau boi dau ,";
                return View(vm);
            }

            var mid = arr.Length / 2;
            var range2Min = 0;
            var range1Min = mid - 5;
            var range3Min = arr.Length - 10;

            // Tim 10 so lon thu 1
            FindMax(arr, range1Min, 10);

            // Tim 10 so lon thu 2
            FindSecond(arr, range1Min, range2Min, 10);

            // Tim 10 so lon thu 3
            FindThird(arr, range1Min, range2Min, range3Min, 10);

            vm.Result = string.Join(',', arr);

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public interface ITransientService
    {
        Guid GetID();
    }

    public interface IScopedService
    {
        Guid GetID();
    }

    public interface ISingletonService
    {
        Guid GetID();
    }

    public class SomeService : ITransientService, IScopedService, ISingletonService
    {
        Guid id;
        public SomeService()
        {
            id = Guid.NewGuid();
        }

        public Guid GetID()
        {
            return id;
        }
    }
}
