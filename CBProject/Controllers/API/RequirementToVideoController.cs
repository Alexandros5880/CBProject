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
    public class RequirementToVideoController : ApiController, IDisposable
    {
        private readonly RequirementsToVideosRepository _requirementsToVideosRepository;

        public RequirementToVideoController(IUnitOfWork unitOfWork)
        {
            this._requirementsToVideosRepository = unitOfWork.RequirementsToVideos;
        }

        // GET api/RequirementToVideo
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._requirementsToVideosRepository
                                        .GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/RequirementToVideo/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._requirementsToVideosRepository
                                        .GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/RequirementToVideo
        public async Task<IHttpActionResult> Post([FromBody] RequirementToVideo obj)
        {
            if (obj == null)
                return NotFound();
            this._requirementsToVideosRepository.Add(obj);
            await this._requirementsToVideosRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/RequirementToVideo/5
        public async Task<IHttpActionResult> Put([FromBody] RequirementToVideo obj)
        {
            if (obj == null)
                return NotFound();
            this._requirementsToVideosRepository.Update(obj);
            await this._requirementsToVideosRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/RequirementToVideo/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._requirementsToVideosRepository.DeleteAsync(id);
            await this._requirementsToVideosRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/RequirementToVideo/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._requirementsToVideosRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/RequirementToVideo/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._requirementsToVideosRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._requirementsToVideosRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}