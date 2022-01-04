using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.HelperModels;
using CBProject.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class VideoController : ApiController, IDisposable
    {
        private readonly VideosRepository _videosRepository;

        public VideoController(IUnitOfWork unitOfWork)
        {
            this._videosRepository = unitOfWork.Videos;
        }

        // GET api/Video
        [HttpGet]
        [Route("api/Video/all")]
        public async Task<IHttpActionResult> Get()
        {
            var videos = await this._videosRepository.GetAllEmptyAsync();
            return Ok(videos);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._videosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}