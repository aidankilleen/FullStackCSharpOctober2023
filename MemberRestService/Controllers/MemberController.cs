using MemberDao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberRestService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IMemberDao _dao;

        public MemberController(IMemberDao dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public List<Member> GetAll()
        {
            return _dao.GetAll();
        }

        [HttpGet("{id}")] //api/Member/5
        public ActionResult<Member> Get(int id)
        {
            try
            {
                return _dao.Get(id);
            }
            catch (MemberDaoException ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _dao.Delete(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult<Member> Add(Member member)
        {
            Member addedMember = _dao.Add(member);
            return Created($"api/Member/{ addedMember.Id }", addedMember);
        }

        [HttpPut("{id}")]
        public ActionResult<Member> Update(Member member)
        {
            Member updatedMember = _dao.Update(member);
            return Ok(updatedMember);
        }
    }
}
