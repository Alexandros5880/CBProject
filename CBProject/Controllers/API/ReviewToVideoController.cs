using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class ReviewToVideoController : ApiController, IDisposable
    {
        private readonly ReviewsToVideosRepository _reviewsToVideosRepository;

        public ReviewToVideoController(IUnitOfWork unitOfWork)
        {
            this._reviewsToVideosRepository = unitOfWork.ReviewsToVideos;
        }

        // GET api/ReviewToVideo
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._reviewsToVideosRepository
                                    .GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/ReviewToVideo/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._reviewsToVideosRepository
                            .GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/ReviewToVideo
        public async Task<IHttpActionResult> Post([FromBody] ReviewToVideo obj)
        {
            if (obj == null)
                return NotFound();
            this._reviewsToVideosRepository.Add(obj);
            await this._reviewsToVideosRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/ReviewToVideo/5
        public async Task<IHttpActionResult> Put([FromBody] ReviewToVideo obj)
        {
            if (obj == null)
                return NotFound();
            this._reviewsToVideosRepository.Update(obj);
            await this._reviewsToVideosRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/ReviewToVideo/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._reviewsToVideosRepository.DeleteAsync(id);
            await this._reviewsToVideosRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._reviewsToVideosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}