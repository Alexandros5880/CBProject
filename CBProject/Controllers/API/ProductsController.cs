using CBProject.HelperClasses.Interfaces;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
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
        private readonly TagsRepository _tagRepsitory;
        private readonly UsersRepo _usersRepo;

        public ProductsController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._videosRepository = unitOfWork.Videos;
            this._ebooksReposotory = unitOfWork.Ebooks;
            this._categoriesRepository = unitOfWork.Categories;
            this._tagRepsitory = unitOfWork.Tags;
            this._usersRepo = (UsersRepo)usersRepo;
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

        [HttpPost]
        [Route("api/products/search/filters")]
        public async Task<IHttpActionResult> GetSearchByFilters(FilterPageViewModel viewModel)
        {
            string category = "", tag = "", title = "", teacher = "";
            if (viewModel.CategoryName != null && viewModel.CategoryName.Length > 0)
                category = viewModel.CategoryName;
            if (viewModel.TagName != null && viewModel.TagName.Length > 0)
                tag = viewModel.TagName;
            if (viewModel.TitleName != null && viewModel.TitleName.Length > 0)
                title = viewModel.TitleName;
            if (viewModel.TeacherName != null && viewModel.TeacherName.Length > 0)
                teacher = viewModel.TeacherName;

            var categories = await this._categoriesRepository
                                .GetAllQueryable()
                                .Where(c => c.Name.Contains(category))
                                .ToListAsync();
            var tags = await this._tagRepsitory
                                .GetAllQueryable()
                                .Where(t => t.Title.Contains(tag))
                                .Select(t => t.ID)
                                .ToListAsync();
            var teachers = await this._usersRepo
                                    .GetAllQuerable()
                                    .Where(u => u.FullName.Contains(teacher) || u.Email.Contains(teacher))
                                    .Select(t => t.Id)
                                    .ToListAsync();



            if (viewModel.Ebooks) // TODO: Products API Controller
            {
                //var ebooks = await this._ebooksReposotory
                //        .GetAllQuerable()
                //        .Include(e => e.TagsToEbooks)
                //        .Where(e => categories.Contains(e.Category))
                //        .Where(e => e.TagsToEbooks.Select(t => t.TagId).Intersect(tags))
                //        .ToListAsync();
            }
            else if (viewModel.Videos)
            {

            }
            return Ok(viewModel);
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