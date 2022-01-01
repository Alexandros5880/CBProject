using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class RatingToEbookController : ApiController, IDisposable
    {
        private readonly RatingsToEbooksRepository _ratingsToEbooks;

        public RatingToEbookController(IUnitOfWork unitOfWork)
        {
            this._ratingsToEbooks = unitOfWork.RatingsToEbooks;
        }

        // GET ap/RatingToEbook
        public async Task<IHttpActionResult> Get()
        {
            var ratingsToEbooks = await this._ratingsToEbooks.GetAllEmptyAsync();
            return Ok(ratingsToEbooks);
        }

        // GET api/RatingToEbook/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var ratingToEbook = await this._ratingsToEbooks.GetEmptyAsync(id);
            if (ratingToEbook == null)
                return NotFound();
            return Ok(ratingToEbook);
        }

        // POST api/RatingToEbook
        public async Task<IHttpActionResult> Post([FromBody] RatingToEbook ratingToEbook)
        {
            if (ratingToEbook == null)
                return NotFound();
            this._ratingsToEbooks.Add(ratingToEbook);
            await this._ratingsToEbooks.SaveAsync();
            return Ok(ratingToEbook);
        }

        // PUT api/RatingToEbook
        public async Task<IHttpActionResult> Put([FromBody] RatingToEbook ratingToEbook)
        {
            if (ratingToEbook == null)
                return NotFound();
            this._ratingsToEbooks.Update(ratingToEbook);
            await this._ratingsToEbooks.SaveAsync();
            return Ok(ratingToEbook);
        }

        // DELETE api/RatingToEbook/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._ratingsToEbooks.DeleteAsync(id);
            await this._ratingsToEbooks.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._ratingsToEbooks.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}