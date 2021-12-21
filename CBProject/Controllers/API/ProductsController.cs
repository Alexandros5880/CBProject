using CBProject.HelperClasses.Interfaces;
using CBProject.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class ProductsController : ApiController
    {
        private readonly VideosRepository _videosRepository;
        private readonly EbooksRepository _ebooksReposotory;
        private readonly CategoriesRepository _categoriesRepository;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            this._videosRepository = unitOfWork.Videos;
            this._ebooksReposotory = unitOfWork.Ebooks;
            this._categoriesRepository = unitOfWork.Categories;
        }

        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            var videos = await this._videosRepository.GetAllQuerable()
                        .ToListAsync();
            var ebooks = await this._ebooksReposotory.GetAllQuerable()
                        .ToListAsync();

            var products = new
            {
                Videos = videos,
                Ebooks = ebooks
            };

            return Ok(products);
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(string search)
        {
            var category = await this._categoriesRepository
                        .GetByNameAsync(search);
            var videos = await this._videosRepository.GetAllQuerable()
                        .Where(v => v.CategoryId == category.ID)
                        .ToListAsync();
            var ebooks = await this._ebooksReposotory.GetAllQuerable()
                        .Where(v => v.CategoryId == category.ID)
                        .ToListAsync();

            var products = new
            {
                Videos = videos,
                Ebooks = ebooks
            };

            return Ok(products);
        }

        [Route("api/products/pagination")]
        public async Task<IHttpActionResult> GetAllPagination(int pagesize)
        {
            return Ok();
        }

        [Route("api/products/search/pagination")]
        public async Task<IHttpActionResult> GetSearchPagination(int pagesize, string search)
        {
            return Ok();
        }







        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}