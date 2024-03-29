﻿using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
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
    public class VideoController : ApiController, IDisposable
    {
        private readonly VideosRepository _videosRepository;
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;

        public VideoController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo)
        {
            this._videosRepository = unitOfWork.Videos;
            this._usersRepo = (UsersRepo)usersRepo;
            this._rolesRepo = (RolesRepo)rolesRepo;
        }

        // GET api/Video
        [HttpGet]
        [Route("api/Video/all")]
        public async Task<IHttpActionResult> Get()
        {
            var videos = await this._videosRepository.GetAllEmptyAsync();
            return Ok(videos);
        }

        // Get All Free And By Product
        [HttpGet]
        [Route("api/Video/user/all")]
        public async Task<IHttpActionResult> GetAll(string userId)
        {
            if (userId == null)
                return BadRequest();
            var logedId = User.Identity.GetUserId();
            var user = await this._usersRepo.GetAsync(userId);
            if ( this._usersRepo.GetRoles(user).Contains("Admin") || this._usersRepo.GetRoles(user).Contains("Manager"))
            {
                var videos = await this._videosRepository.GetAllEmptyAsync();
                return Ok(videos);
            } else
            {
                var videos = await this._videosRepository
                                        .GetAllQueryable()
                                        .Where(v => !v.SubscriptionPackages.Any() && v.CreatorId.Equals(logedId))
                                        .ToListAsync();
                return Ok(videos);
            }
        }

        // Get All Free And By Product
        [HttpGet]
        [Route("api/Video/product/all")]
        public async Task<IHttpActionResult> GetByProduct(string userId, int? packageId)
        {
            if (userId == null)
                return BadRequest();
            if (packageId == null)
                return BadRequest();

            var user = await this._usersRepo.GetAsync(userId);
            if (this._usersRepo.GetRoles(user).Contains("Admin") || this._usersRepo.GetRoles(user).Contains("Manager"))
            {
                var videos = await this._videosRepository.GetAllEmptyAsync();
                return Ok(videos);
            }
            else
            {
                var videos = await this._videosRepository.GetAllByPackageAsync(packageId);
                return Ok(videos);
            }
        }

        // GET api/Video/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var video = await this._videosRepository.GetEmptyAsync(id);
            if (video == null)
                return NotFound();
            return Ok(video);
        }

        // POST api/Video
        public async Task<IHttpActionResult> Post([FromBody] Video video)
        {
            if (video == null)
                return NotFound();
            this._videosRepository.Add(video);
            await this._videosRepository.SaveAsync();
            return Ok(video);
        }

        // PUT api/Video
        public async Task<IHttpActionResult> Put([FromBody] Video video)
        {
            if (video == null)
                return NotFound();
            this._videosRepository.Update(video);
            await this._videosRepository.SaveAsync();
            return Ok(video);
        }

        // DELETE api/Video/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._videosRepository.DeleteAsync(id);
            await this._videosRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/Video/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._videosRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/Video/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._videosRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        [HttpPost]
        [Route("api/Video/AddRate")]
        public async Task<IHttpActionResult> AddRate([FromBody] VideoRateAPI model)
        {
            if (User.Identity.IsAuthenticated)
            {
                await this._videosRepository.AddRatingAsync(model.VideoId, User.Identity.GetUserId(), model.Rate);
            }
            return Ok();
        }

        [HttpPost]
        [Route("api/Video/AddComment")]
        public async Task<IHttpActionResult> AddComment([FromBody] VideoCommentAPI model)
        {
            if (User.Identity.IsAuthenticated)
            {
                await this._videosRepository.AddReviewAsync(model.VideoId, User.Identity.GetUserId(), model.Comment);
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._videosRepository.Dispose();
                this._usersRepo.Dispose();
                this._rolesRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}