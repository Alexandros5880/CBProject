using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
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