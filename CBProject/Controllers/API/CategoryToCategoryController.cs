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
    public class CategoryToCategoryController : ApiController, IDisposable
    {
        private readonly CategoryToCategoryRepository _catToCatRepository;

        public CategoryToCategoryController(IUnitOfWork unitOfWork)
        {
            this._catToCatRepository = unitOfWork.CategoryToCategory;
        }

        // GET api/CategoryToCategory
        public async Task<IHttpActionResult> Get()
        {
            var catToCat = await this._catToCatRepository.GetAllEmptyAsync();
            return Ok(catToCat);
        }

        // GET api/CategoryToCategory/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var catToCat = await this._catToCatRepository.GetEmptyAsync(id);
            if (catToCat == null)
                return NotFound();
            return Ok(catToCat);
        }

        // POST api/CategoryToCategory
        public async Task<IHttpActionResult> Post([FromBody] CategoryToCategory catToCat)
        {
            if (catToCat == null)
                return NotFound();
            this._catToCatRepository.Add(catToCat);
            await this._catToCatRepository.SaveAsync();
            return Ok(catToCat);
        }

        // PUT api/CategoryToCategory
        public async Task<IHttpActionResult> Put([FromBody] CategoryToCategory catToCat)
        {
            if (catToCat == null)
                return NotFound();
            this._catToCatRepository.Update(catToCat);
            await this._catToCatRepository.SaveAsync();
            return Ok(catToCat);
        }

        // DELETE api/CategoryToCategory/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._catToCatRepository.DeleteAsync(id);
            await this._catToCatRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/CategoryToCategory/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._catToCatRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/CategoryToCategory/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._catToCatRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._catToCatRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}