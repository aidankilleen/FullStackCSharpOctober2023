using MemberDao;
using Microsoft.AspNetCore.Mvc;

namespace WebAppHelloWorld.Controllers
{
    public class MembersController : Controller
    {
        string connectionString = "Server=tcp:professionaltraining.database.windows.net,1433;Initial Catalog=trainingdb;Persist Security Info=False;User ID=<>;Password=<>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private IMemberDao dao;
        private ILogger<MembersController> logger;

        public MembersController(IMemberDao dao,
                                ILogger<MembersController> logger)
        {
            this.dao = dao;
            this.logger = logger;

            logger.LogInformation("***Members controller instantiated");
            //dao = new SqlMemberDao(connectionString);
        }

        public IActionResult Index()
        {
            ViewBag.Members = dao.GetAll();
            return View();
        }

        public IActionResult Detail(int id)
        {
            Member member = dao.Get(id);

            ViewBag.Id = id;
            ViewBag.Member = member;
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // show a form
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public IActionResult DoDelete(int id)
        {
            //int id = int.Parse(Request.Form["id"]);
            if (Request.Form["submit"].Equals("Ok")) { 

                // actually do the delete
                dao.Delete(id);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Member";
            ViewBag.Action = "DoAdd";
            ViewBag.Label = "Add Member";
            Member newMember = new Member { Name = "", Email = "", Active = false };
            return View("MemberForm", newMember);
        }
        [HttpPost]
        public IActionResult DoAdd(Member member)
        {
            Member addedMember = dao.Add(member);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Title = "Edit Member";
            ViewBag.Action = "DoUpdate";
            ViewBag.Label = "Save Changes";
            Member memberToUpdate = dao.Get(id);
            return View("MemberForm", memberToUpdate);
        }

        [HttpPost]
        public IActionResult DoUpdate(Member member)
        {
            dao.Update(member);
            return RedirectToAction("Index");
        }
    }
}
