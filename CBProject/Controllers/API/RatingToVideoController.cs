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
    public class RatingToVideoController : ApiController, IDisposable
    {
        private readonly RatingsToVideosRepository _ratingsToVideos;

        public RatingToVideoController(IUnitOfWork unitOfWork)
        {
            this._ratingsToVideos = unitOfWork.RatingsToVideos;
        }

        // GET api/RatingToVideo
        public async Task<IHttpActionResult> Get()
        {
            var ratingsToVideos = await this._ratingsToVideos.GetAllEmptyAsync();
            return Ok(ratingsToVideos);
        }

        // GET api/RatingToVideo/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var ratingToVideo = await this._ratingsToVideos.GetEmptyAsync(id);
            if (ratingToVideo == null)
                return NotFound();
            return Ok(ratingToVideo);
        }

        // POST api/RatingToVideo
        public async Task<IHttpActionResult> Post([FromBody] RatingToVideo ratingToVideo)
        {
            if (ratingToVideo == null)
                return NotFound();
            this._ratingsToVideos.Add(ratingToVideo);
            await this._ratingsToVideos.SaveAsync();
            return Ok(ratingToVideo);
        }

        // PUT api/RatingToVideo
        public async Task<IHttpActionResult> Put([FromBody] RatingToVideo ratingToVideo)
        {
            if (ratingToVideo == null)
                return NotFound();
            this._ratingsToVideos.Update(ratingToVideo);
            await this._ratingsToVideos.SaveAsync();
            return Ok(ratingToVideo);
        }

        // DELETE api/RatingToVideo/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._ratingsToVideos.DeleteAsync(id);
            await this._ratingsToVideos.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/RatingToVideo/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._ratingsToVideos.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/RatingToVideo/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._ratingsToVideos.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._ratingsToVideos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}