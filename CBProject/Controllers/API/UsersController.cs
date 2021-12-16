using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class UsersController : ApiController
    {
        private readonly RolesRepo _rolesRepo;
        private readonly UsersRepo _usersRepo;
        public UsersController(IRolesRepo rolesRepo, IUsersRepo usersRepo)
        {
            this._rolesRepo = (RolesRepo)rolesRepo;
            this._usersRepo = (UsersRepo)usersRepo;
        }

        [HttpGet]
        [Route("api/get/logged/logged")]
        public async Task<IHttpActionResult> GetLogged()
        {
            var id = User.Identity.GetUserId();
            return Ok(await this._usersRepo.GetAsync(id));
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(string id)
        {
            if (id == null)
                return NotFound();
            var user = await _usersRepo.GetAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}