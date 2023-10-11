using MemberDao;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppHelloWorld.Models;

namespace WebAppHelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private IMemberDao dao = new InMemoryMemberDao();
        string connectionString = "Server=tcp:professionaltraining.database.windows.net,1433;Initial Catalog=trainingdb;Persist Security Info=False;User ID=ptdbuser;Password=Training2023#@!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private IMemberDao dao;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _logger.LogInformation("****Testing the logger");
            dao = new SqlMemberDao(connectionString);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Members()
        {
            string title = "The Members Page";
            Random r = new Random();
            int rv = r.Next(100);

            ViewBag.Title = title;
            ViewBag.Members = dao.GetAll();
            ViewBag.rv = rv;
            dao.Close();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}