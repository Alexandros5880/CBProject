using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.HelperModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class EbookController : ApiController, IDisposable
    {
        private readonly EbooksRepository _ebooksRepository;
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;

        public EbookController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._usersRepo = (UsersRepo) usersRepo;
            this._rolesRepo = (RolesRepo) rolesRepo;
        }

        // GET api/Ebook
        [HttpGet]
        [Route("api/Ebook/all")]
        public async Task<IHttpActionResult> Get()
        {
            var ebooks = await this._ebooksRepository.GetAllEmptyAsync();
            return Ok(ebooks);
        }

        // Get All Free And By Product
        [HttpGet]
        [Route("api/Ebook/user/all")]
        public async Task<IHttpActionResult> GetAll(string userId)
        {
            if (userId == null)
                return BadRequest();
            var logedId = User.Identity.GetUserId();
            var user = await this._usersRepo.GetAsync(userId);
            if (this._usersRepo.GetRoles(user).Contains("Admin"))
            {
                var ebooks = await this._ebooksRepository.GetAllEmptyAsync();
                return Ok(ebooks);
            }
            else
            {
                var ebooks = await this._ebooksRepository
                                        .GetAllQueryable()
                                        .Where(e => !e.SubscriptionPackages.Any() %% e.CreatorId.Equals(logedId))
                                        .ToListAsync();
                return Ok(ebooks);
            }
        }

        // Get All Free And By Product
        [HttpGet]
        [Route("api/Ebook/product/all")]
        public async Task<IHttpActionResult> GetByProduct(string userId, int? packageId)
        {
            if (userId == null)
                return BadRequest();

            if (packageId == null)
                return BadRequest();

            var user = await this._usersRepo.GetAsync(userId);
            if (this._usersRepo.GetRoles(user).Contains("Admin"))
            {
                var ebooks = await this._ebooksRepository.GetAllEmptyAsync();
                return Ok(ebooks);
            }
            else
            {
                var ebooks = await this._ebooksRepository.GetAllByPackageAsync(packageId);
                return Ok(ebooks);
            }
        }

        // GET api/Ebook/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var video = await this._ebooksRepository.GetEmptyAsync(id);
            if (video == null)
                return NotFound();
            return Ok(video);
        }

        // POST api/Ebook
        public async Task<IHttpActionResult> Post([FromBody] Ebook video)
        {
            if (video == null)
                return NotFound();
            this._ebooksRepository.Add(video);
            await this._ebooksRepository.SaveAsync();
            return Ok(video);
        }

        // PUT api/Ebook
        public async Task<IHttpActionResult> Put([FromBody] Ebook video)
        {
            if (video == null)
                return NotFound();
            this._ebooksRepository.Update(video);
            await this._ebooksRepository.SaveAsync();
            return Ok(video);
        }

        // DELETE api/Ebook/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._ebooksRepository.DeleteAsync(id);
            await this._ebooksRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/Ebook/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._ebooksRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/Ebook/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._ebooksRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        [HttpPost]
        [Route("api/Ebook/AddRate")]
        public async Task<IHttpActionResult> AddRate([FromBody] EbookRateAPI model)
        {
            if (User.Identity.IsAuthenticated)
            {
                await this._ebooksRepository.AddRatingAsync(model.EbookId, User.Identity.GetUserId(), model.Rate);
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Ebook/AddComment")]
        public async Task<IHttpActionResult> AddComment([FromBody] EbookCommentAPI model)
        {
            if (User.Identity.IsAuthenticated)
            {
                await this._ebooksRepository.AddReviewAsync(model.EbookId, User.Identity.GetUserId(), model.Comment);
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._ebooksRepository.Dispose();
                this._usersRepo.Dispose();
                this._rolesRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}