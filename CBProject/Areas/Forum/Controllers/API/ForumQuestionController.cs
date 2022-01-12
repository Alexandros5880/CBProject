using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories;
using CBProject.HelperClasses.Interfaces;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Areas.Forum.Controllers.API
{
    public class ForumQuestionController : ApiController, IDisposable
    {
        private readonly ForumQuestionsRepository _forumeQuestionsRepository;
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;

        public ForumQuestionController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo)
        {
            this._forumeQuestionsRepository = unitOfWork.ForumQuestions;
            this._usersRepo = (UsersRepo)usersRepo;
            this._rolesRepo = (RolesRepo)rolesRepo;
        }

        // GET api/ForumQuestion
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._forumeQuestionsRepository.GetAllEmptyAsync();
            if (obj == null || obj.Count == 0)
                return BadRequest();
            return Ok(obj);
        }

        // GET api/ForumQuestion/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return BadRequest();
            var obj = await this._forumeQuestionsRepository.GetEmptyAsync(id);
            if (obj == null)
                return BadRequest();
            return Ok(obj);
        }

        // POST api/ForumQuestion
        public async Task<IHttpActionResult> Post([FromBody] ForumQuestion obj)
        {
            if (obj == null)
                return BadRequest();
            this._forumeQuestionsRepository.Add(obj);
            await this._forumeQuestionsRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/ForumQuestion/5
        public async Task<IHttpActionResult> Put([FromBody] ForumQuestion obj)
        {
            if (obj == null)
                return BadRequest();
            this._forumeQuestionsRepository.Update(obj);
            await this._forumeQuestionsRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/ForumQuestion/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            await this._forumeQuestionsRepository.DeleteAsync(id);
            await this._forumeQuestionsRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._forumeQuestionsRepository.Dispose();
                this._usersRepo.Dispose();
                this._rolesRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}