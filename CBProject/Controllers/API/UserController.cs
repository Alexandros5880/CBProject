using CBProject.Models;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class UserController : ApiController, IDisposable
    {
        private readonly UsersRepo _usersRepo;

        public UserController(IUsersRepo usersRepo)
        {
            this._usersRepo = (UsersRepo)usersRepo;
        }

        // GET api/User
        [HttpGet]
        [Route("api/User/all")]
        public async Task<IHttpActionResult> Get()
        {
            var users = await this._usersRepo.GetAllAsync();
            return Ok(users);
        }

        // GET api/User/5
        public async Task<IHttpActionResult> Get(string id)
        {
            if (id == null)
                return NotFound();
            var user = await this._usersRepo.GetAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/User
        public async Task<IHttpActionResult> Post([FromBody] ApplicationUser user)
        {
            if (user == null)
                return NotFound();
            await this._usersRepo.AddAsync(user);
            return Ok(user);
        }

        // PUT api/User
        public async Task<IHttpActionResult> Put([FromBody] ApplicationUser user)
        {
            if (user == null)
                return NotFound();
            await this._usersRepo.UpdateAsync(user);
            return Ok(user);
        }

        // DELETE api/User/5
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();
            await this._usersRepo.DeleteAsync(id);
            return Ok();
        }

        // DELETE api/User/real/5
        [HttpDelete]
        [Route("api/User/real/{id}")]
        public async Task<IHttpActionResult> DeleteReal(string id)
        {
            if (id == null)
                return NotFound();
            await this._usersRepo.DeleteRealAsync(id);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._usersRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}