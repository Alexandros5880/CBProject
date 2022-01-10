﻿using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.HelperModels;
using CBProject.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class EbookController : ApiController, IDisposable
    {
        private readonly EbooksRepository _ebooksRepository;

        public EbookController(IUnitOfWork unitOfWork)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
        }

        // GET api/Ebook
        [HttpGet]
        [Route("api/Ebook/all")]
        public async Task<IHttpActionResult> Get()
        {
            var videos = await this._ebooksRepository.GetAllEmptyAsync();
            return Ok(videos);
        }

        // Get All Free And By Product
        [HttpGet]
        [Route("api/Ebook/product/all")]
        public async Task<IHttpActionResult> GetByProduct(int? packageId)
        {
            var ebooks = await this._ebooksRepository.GetAllByPackageAsync(packageId);
            return Ok(ebooks);
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
            }
            base.Dispose(disposing);
        }
    }
}