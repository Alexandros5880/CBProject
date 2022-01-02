﻿using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class ReviewController : ApiController, IDisposable
    {
        private readonly ReviewsRepository _reviewsRepository;

        public ReviewController(IUnitOfWork unitOfWork)
        {
            this._reviewsRepository = unitOfWork.Reviews;
        }

        // GET api/Review
        [HttpGet]
        [Route("api/Review/all")]
        public async Task<IHttpActionResult> Get()
        {
            var reviews = await this._reviewsRepository.GetAllEmptyAsync();
            return Ok(reviews);
        }

        // GET api/Review/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var review = await this._reviewsRepository.GetEmptyAsync(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        // POST api/Review
        public async Task<IHttpActionResult> Post([FromBody] Review review)
        {
            if (review == null)
                return NotFound();
            this._reviewsRepository.Add(review);
            await this._reviewsRepository.SaveAsync();
            return Ok(review);
        }

        // PUT api/Review
        public async Task<IHttpActionResult> Put([FromBody] Review review)
        {
            if (review == null)
                return NotFound();
            this._reviewsRepository.Update(review);
            await this._reviewsRepository.SaveAsync();
            return Ok(review);
        }

        // DELETE api/Review/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._reviewsRepository.DeleteAsync(id);
            await this._reviewsRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/Review/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._reviewsRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/Review/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._reviewsRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._reviewsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}