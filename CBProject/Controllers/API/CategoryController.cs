using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class CategoryController : ApiController, IDisposable
    {

        private readonly CategoriesRepository _categoriesRepoditory;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this._categoriesRepoditory = unitOfWork.Categories;
        }

        // GET api/Categories
        public async Task<IHttpActionResult> Get()
        {
            var categories = await this._categoriesRepoditory.GetAllEmptyAsync();
            return Ok(categories);
        }

        // GET api/Categories/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var category = await this._categoriesRepoditory.GetEmptyAsync(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        // POST api/Categories
        public async Task<IHttpActionResult> Post([FromBody] Category category)
        {
            if (category == null)
                return NotFound();
            this._categoriesRepoditory.Add(category);
            await this._categoriesRepoditory.SaveAsync();
            return Ok(category);
        }

        // PUT api/Categories
        public async Task<IHttpActionResult> Put([FromBody] Category category)
        {
            if (category == null)
                return NotFound();
            this._categoriesRepoditory.Update(category);
            await this._categoriesRepoditory.SaveAsync();
            return Ok(category);
        }

        // DELETE api/Categories/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._categoriesRepoditory.DeleteAsync(id);
            await this._categoriesRepoditory.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._categoriesRepoditory.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}