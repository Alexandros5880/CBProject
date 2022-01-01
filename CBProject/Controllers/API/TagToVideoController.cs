using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class TagToVideoController : ApiController, IDisposable
    {
        private readonly TagsToVideosRepository _tagsToVideosRepository;

        public TagToVideoController(IUnitOfWork unitOfWork)
        {
            this._tagsToVideosRepository = unitOfWork.TagsToVideos;
        }

        // GET api/TagToVideo
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._tagsToVideosRepository
                                            .GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/TagToVideo/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._tagsToVideosRepository
                                            .GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/TagToVideo
        public async Task<IHttpActionResult> Post([FromBody] TagToVideo obj)
        {
            if (obj == null)
                return NotFound();
            this._tagsToVideosRepository.Add(obj);
            await this._tagsToVideosRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/TagToVideo/5
        public async Task<IHttpActionResult> Put([FromBody] TagToVideo obj)
        {
            if (obj == null)
                return NotFound();
            this._tagsToVideosRepository.Update(obj);
            await this._tagsToVideosRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/TagToVideo/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._tagsToVideosRepository.DeleteAsync(id);
            await this._tagsToVideosRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._tagsToVideosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}