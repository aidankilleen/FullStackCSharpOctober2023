using Microsoft.AspNetCore.Mvc;

namespace MiddlewareInvestigation.Controllers
{
    public class MarketingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Message1()
        {
            return View();
        }

        public IActionResult Message2()
        {
            return View();
        }


    }
}
