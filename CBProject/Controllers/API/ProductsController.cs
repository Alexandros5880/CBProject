using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
        private readonly SubscriptionPackageRepository _subscriptionPackageRepository;

        public ProductsController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._videosRepository = unitOfWork.Videos;
            this._ebooksReposotory = unitOfWork.Ebooks;
            this._categoriesRepository = unitOfWork.Categories;
            this._tagRepsitory = unitOfWork.Tags;
            this._usersRepo = (UsersRepo)usersRepo;
            this._subscriptionPackageRepository = unitOfWork.SubscriptionPackages;
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
                                .Select(c => c.ID)
                                .ToListAsync();
            var tags = await this._tagRepsitory
                                .GetAllQueryable()
                                .Where(t => t.Title.Contains(tag))
                                .Select(t => t.ID)
                                .ToListAsync();
            var teachers = await this._usersRepo
                                    .GetAllQuerable()
                                    .Where(u => u.FirstName.Contains(teacher) || 
                                                u.LastName.Contains(teacher) || 
                                                u.Email.Contains(teacher))
                                    .Select(t => t.Id)
                                    .ToListAsync();

            var ebooks = await this._ebooksReposotory
                        .GetAllQuerable()
                        .Where(e => categories.Any() ? categories.Contains(e.CategoryId) : true)
                        .Where(e => tags.Any() ? e.TagsToEbooks.Select(t => t.TagId).Intersect(tags).Any() : true)
                        .Where(e => teachers.Any() ? teachers.Contains(e.CreatorId): true)
                        .Where(e => viewModel.TitleName.Length > 0 ? e.Title.Contains(viewModel.TitleName) : true)
                        .ToListAsync();

            var videos = await this._videosRepository
                        .GetAllQuerable()
                        .Where(e => categories.Any() ? categories.Contains(e.CategoryId) : true)
                        .Where(e => tags.Any() ? e.TagsToVideos.Select(t => t.TagId).Intersect(tags).Any() : true)
                        .Where(e => teachers.Any() ? teachers.Contains(e.CreatorId) : true)
                        .Where(e => viewModel.TitleName.Length > 0 ? e.Title.Contains(viewModel.TitleName) : true)
                        .ToListAsync();

            var products = new
            {
                Videos = videos,
                Ebooks = ebooks
            };

            return Ok(products);
        }

        [HttpPost]
        [Route("api/products/payment/frame")]
        public async Task<IHttpActionResult> GetPaynmentFrame(MyPayment payment)
        {
            var myPayment = new
            {
                transaction_details = new
                {
                    order_id = payment.TransactionDetails.OrderId,
                    gross_amount = payment.TransactionDetails.GrossAmount
                },
                credit_card = new
                {
                    secure = payment.Secure
                },
                customer_details = new
                {
                    first_name = payment.User.FirstName,
                    last_name = payment.User.LastName,
                    email = payment.User.Email,
                    phone = payment.User.PhoneNumber
                }
            };
            const string baseUri = "https://app.sandbox.midtrans.com/snap/v1/transactions";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", payment.Auth.UserName);
            var json = JsonConvert.SerializeObject(myPayment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(baseUri, content);
            if (result.IsSuccessStatusCode)
            {
                return Ok(await result.Content.ReadAsStringAsync());
            }
            else
            {
                return Ok("Error");
            }
        }

        [HttpGet]
        [Route("api/products/packages")]
        public async Task<IHttpActionResult> GetPackages()
        {
            return Ok(await this._subscriptionPackageRepository
                                .GetAllAsync());
        }

        [HttpGet]
        [Route("api/user")]
        public async Task<IHttpActionResult> GetUser(string userId)
        {
            return Ok(await this._usersRepo.GetAsync(userId));
        }

        [HttpGet]
        [Route("api/logged/user")]
        public async Task<IHttpActionResult> GetLoggedInUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = await this._usersRepo.GetAsync(userId);
                return Ok(user);
            }
            else
            {
                return Ok("null");
            }
        }

        [HttpGet]
        [Route("api/packages/")]
        public async Task<IHttpActionResult> GetSubscriptionPackage(int id)
        {
            return Ok(await this._subscriptionPackageRepository.GetAsync(id));
        }
    }
}