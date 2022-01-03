using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class ReviewToEbookController : ApiController, IDisposable
    {
        private readonly ReviewsToEbooksRepository _reviewsToEbooksRepository;

        public ReviewToEbookController(IUnitOfWork unitOfWork)
        {
            this._reviewsToEbooksRepository = unitOfWork.ReviewsToEbooks;
        }

        // GET api/ReviewToEbook
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._reviewsToEbooksRepository
                                    .GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/ReviewToEbook/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._reviewsToEbooksRepository
                                    .GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/ReviewToEbook
        public async Task<IHttpActionResult> Post([FromBody] ReviewToEbook obj)
        {
            if (obj == null)
                return NotFound();
            this._reviewsToEbooksRepository.Add(obj);
            await this._reviewsToEbooksRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/ReviewToEbook/5
        public async Task<IHttpActionResult> Put([FromBody] ReviewToEbook obj)
        {
            if (obj == null)
                return NotFound();
            this._reviewsToEbooksRepository.Update(obj);
            await this._reviewsToEbooksRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/ReviewToEbook/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._reviewsToEbooksRepository.DeleteAsync(id);
            await this._reviewsToEbooksRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/ReviewToEbook/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._reviewsToEbooksRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/ReviewToEbook/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._reviewsToEbooksRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._reviewsToEbooksRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}