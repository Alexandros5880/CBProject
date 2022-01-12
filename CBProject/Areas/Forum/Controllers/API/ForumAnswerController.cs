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
    public class ForumAnswerController : ApiController, IDisposable
    {
        private readonly ForumAnswersRepository _forumeAnswersRepository;
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;

        public ForumAnswerController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo)
        {
            this._forumeAnswersRepository = unitOfWork.ForumAnswers;
            this._usersRepo = (UsersRepo)usersRepo;
            this._rolesRepo = (RolesRepo)rolesRepo;
        }

        // GET api/ForumAnswer
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._forumeAnswersRepository.GetAllEmptyAsync();
            if (obj == null || obj.Count == 0)
                return BadRequest();
            return Ok(obj);
        }

        // GET api/ForumAnswer/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return BadRequest();
            var obj = await this._forumeAnswersRepository.GetEmptyAsync(id);
            if (obj == null)
                return BadRequest();
            return Ok(obj);
        }

        // POST api/ForumAnswer
        public async Task<IHttpActionResult> Post([FromBody] ForumAnswer obj)
        {
            if (obj == null)
                return BadRequest();
            this._forumeAnswersRepository.Add(obj);
            await this._forumeAnswersRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/ForumAnswer/5
        public async Task<IHttpActionResult> Put([FromBody] ForumAnswer obj)
        {
            if (obj == null)
                return BadRequest();
            this._forumeAnswersRepository.Update(obj);
            await this._forumeAnswersRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/ForumAnswer/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            await this._forumeAnswersRepository.DeleteAsync(id);
            await this._forumeAnswersRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._forumeAnswersRepository.Dispose();
                this._usersRepo.Dispose();
                this._rolesRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}