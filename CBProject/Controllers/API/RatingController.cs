using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class RatingController : ApiController, IDisposable
    {
        private readonly RatingsRepository _retingsRepository;

        public RatingController(IUnitOfWork unitOfWork)
        {
            this._retingsRepository = unitOfWork.Ratings;
        }

        // GET api/Rating
        public async Task<IHttpActionResult> Get()
        {
            var ratings = await this._retingsRepository.GetAllAsync();
            return Ok(ratings);
        }

        // GET api/Rating/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var rating = await this._retingsRepository.GetEmptyAsync(id);
            if (rating == null)
                return NotFound();
            return Ok(rating);
        }

        // POST api/Rating
        public async Task<IHttpActionResult> Post([FromBody] Rating rating)
        {
            if (rating == null)
                return NotFound();
            this._retingsRepository.Add(rating);
            await this._retingsRepository.SaveAsync();
            return Ok(rating);
        }

        // PUT api/Rating
        public async Task<IHttpActionResult> Put([FromBody] Rating rating)
        {
            if (rating == null)
                return NotFound();
            this._retingsRepository.Update(rating);
            await this._retingsRepository.SaveAsync();
            return Ok(rating);
        }

        // DELETE api/Rating/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._retingsRepository.DeleteAsync(id);
            await this._retingsRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/Rating/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._retingsRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/Rating/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._retingsRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._retingsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}