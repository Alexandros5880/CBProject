using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
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

        // PUT api/CategoryToCategory/5
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