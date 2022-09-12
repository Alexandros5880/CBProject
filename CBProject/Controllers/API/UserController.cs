using CBProject.HelperClasses;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System;
using System.Linq;
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

        [HttpGet]
        [Route("api/User/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._usersRepo.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/User/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._usersRepo.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.Id), number, StaticImfo.PageSize);
            return Ok(myPage);
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