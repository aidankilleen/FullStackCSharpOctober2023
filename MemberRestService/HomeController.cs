using Microsoft.AspNetCore.Mvc;

namespace MemberRestService
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
