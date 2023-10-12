using MemberDao;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MemberRestWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        IMemberDao _dao;

        public MembersController(IMemberDao dao)
        {
            this._dao = dao;
        }

        // GET: api/<MembersController>
        [HttpGet]
        public IEnumerable<Member> Get()
        {
            return _dao.GetAll();
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
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

        // POST api/<MembersController>
        [HttpPost]
        public ActionResult<Member> Post([FromBody] Member member)
        {
            Member addedMember = _dao.Add(member);
            return Created($"/api/Members/{addedMember.Id}", addedMember);
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public ActionResult<Member> Put(int id, [FromBody] Member member)
        {
            Member updatedMember = _dao.Update(member);
            return Ok(updatedMember);
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _dao.Delete(id);
            return Ok();
        }
    }
}
