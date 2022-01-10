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
    public class TagController : ApiController, IDisposable
    {
        private readonly TagsRepository _tagsRepository;

        public TagController(IUnitOfWork unitOfWork)
        {
            this._tagsRepository = unitOfWork.Tags;
        }

        // GET api/Tag
        [HttpGet]
        [Route("api/Tag/all")]
        public async Task<IHttpActionResult> Get()
        {
            var tags = await this._tagsRepository.GetAllAsync();
            return Ok(tags);
        }

        // GET api/Tag/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var tag = await this._tagsRepository.GetEmptyAsync(id);
            if (tag == null)
                return NotFound();
            return Ok(tag);
        }

        // POST api/Tag
        public async Task<IHttpActionResult> Post([FromBody] Tag tag)
        {
            if (tag == null)
                return NotFound();
            this._tagsRepository.Add(tag);
            await this._tagsRepository.SaveAsync();
            return Ok(tag);
        }

        // PUT api/Tag
        public async Task<IHttpActionResult> Put([FromBody] Tag tag)
        {
            if (tag == null)
                return NotFound();
            this._tagsRepository.Update(tag);
            await this._tagsRepository.SaveAsync();
            return Ok(tag);
        }

        // DELETE api/Tag/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._tagsRepository.DeleteAsync(id);
            await this._tagsRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/Tag/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._tagsRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/Tag/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._tagsRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._tagsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}