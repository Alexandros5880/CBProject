using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories;
using System;
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

        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            var videos = await this._videosRepository.GetAllEmptyAsync();
            return Ok(videos);
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var video = await this._videosRepository.GetEmptyAsync(id);
            if (video == null)
                return NotFound();
            return Ok(video);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody] Video video)
        {
            if (video == null)
                return NotFound();
            this._videosRepository.Add(video);
            await this._videosRepository.SaveAsync();
            return Ok(video);
        }

        // PUT api/<controller>
        public async Task<IHttpActionResult> Put([FromBody] Video video)
        {
            if (video == null)
                return NotFound();
            this._videosRepository.Update(video);
            await this._videosRepository.SaveAsync();
            return Ok(video);
        }

        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._videosRepository.DeleteAsync(id);
            await this._videosRepository.SaveAsync();
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