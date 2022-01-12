using CBProject.Areas.Forum.Repositories;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Areas.Forum.Controllers.API
{
    public class ForumMessageController : ApiController, IDisposable
    {
        private readonly ForumMessagesRepository _forumeMessagesRepository;
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;

        public ForumMessageController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo)
        {
            this._forumeMessagesRepository = unitOfWork.ForumMessages;
            this._usersRepo = (UsersRepo)usersRepo;
            this._rolesRepo = (RolesRepo)rolesRepo;
        }

        // GET api/ForumMessage
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._forumeMessagesRepository.GetAllEmptyAsync();
            return Ok();
        }

        // GET api/ForumMessage/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return BadRequest();
            return Ok(); ;
        }

        // POST api/ForumMessage
        public async Task<IHttpActionResult> Post([FromBody] ForumMessage obj)
        {
            if (obj == null)
                return BadRequest();
            this._forumeMessagesRepository.Add(obj);
            await this._forumeMessagesRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/ForumMessage/5
        public async Task<IHttpActionResult> Put([FromBody] ForumMessage obj)
        {
            if (obj == null)
                return BadRequest();
            this._forumeMessagesRepository.Update(obj);
            await this._forumeMessagesRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/ForumMessage/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            await this._forumeMessagesRepository.DeleteAsync(id);
            await this._forumeMessagesRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/forumemessage/user")]
        public async Task<IHttpActionResult> GetUser(int? id)
        {
            if (id == null)
                return BadRequest();
            var message = await this._forumeMessagesRepository.GetEmptyAsync(id);
            if (message == null)
                return BadRequest();
            var user = await this._usersRepo.GetAsync(message.UserId);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }

        // DELETE api/ForumMessage/5
        [HttpGet]
        [Route("api/forumemessage/roles")]
        public async Task<IHttpActionResult> GetRoles(int? id)
        {
            if (id == null)
                return BadRequest();
            var message = await this._forumeMessagesRepository.GetEmptyAsync(id);
            if (message == null)
                return BadRequest();
            var user = await this._usersRepo.GetAsync(message.UserId);
            if (user == null)
                return BadRequest();
            var rolesIds = await user.Roles.AsQueryable()
                                        .Select(r => r.RoleId)
                                        .ToListAsync();
            var roles = new List<ApplicationRole>();
            foreach (var roleId in rolesIds)
            {
                roles.Add(await this._rolesRepo.GetAsync(roleId));
            }
            return Ok(roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._forumeMessagesRepository.Dispose();
                this._usersRepo.Dispose();
                this._rolesRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}