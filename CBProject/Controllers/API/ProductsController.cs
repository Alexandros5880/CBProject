using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
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
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo)
        {
            this._usersRepo = (UsersRepo)usersRepo;
            this._rolesRepo = (RolesRepo)rolesRepo;
            this._unitOfWork = unitOfWork;
        }
        public async Task<IHttpActionResult> Get()
        {
            var videos = await this._unitOfWork.Videos.GetAllQuerable()
                        .ToListAsync();
            var ebooks = await this._unitOfWork.Ebooks.GetAllQuerable()
                        .ToListAsync();

            var products = new
            {
                Videos = videos,
                Ebooks = ebooks
            };

            return Ok(products);
        }
        public async Task<IHttpActionResult> Get(string search)
        {
            var category = await this._unitOfWork.Categories
                        .GetByNameAsync(search);
            var videos = await this._unitOfWork.Videos.GetAllQuerable()
                        .Where(v => v.CategoryId == category.ID)
                        .ToListAsync();
            var ebooks = await this._unitOfWork.Ebooks.GetAllQuerable()
                        .Where(v => v.CategoryId == category.ID)
                        .ToListAsync();
            var products = new
            {
                Videos = videos,
                Ebooks = ebooks
            };
            return Ok(products);
        }
        [HttpGet]
        [Route("api/products/contenst/bycategory")]
        public async Task<IHttpActionResult> GetContentsByCategoryId(int id)
        {
            var category = await this._unitOfWork.Categories
                        .GetAsync(id);
            var videos = await this._unitOfWork.Videos.GetAllQuerable()
                        .Where(v => v.CategoryId == category.ID)
                        .ToListAsync();
            var ebooks = await this._unitOfWork.Ebooks.GetAllQuerable()
                        .Where(v => v.CategoryId == category.ID)
                        .ToListAsync();
            var products = new
            {
                Videos = videos,
                Ebooks = ebooks
            };
            return Ok(products);
        }
        [HttpGet]
        [Route("api/products/contenst/bycategory")]
        public async Task<IHttpActionResult> GetContentsByCategoryName(string name)
        {
            var category = await this._unitOfWork.Categories
                        .GetByNameAsync(name);
            var videos = await this._unitOfWork.Videos.GetAllQuerable()
                        .Where(v => v.CategoryId == category.ID)
                        .ToListAsync();
            var ebooks = await this._unitOfWork.Ebooks.GetAllQuerable()
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

            var categories = await this._unitOfWork.Categories
                                .GetAllQueryable()
                                .Where(c => c.Name.Contains(category))
                                .Select(c => c.ID)
                                .ToListAsync();
            var tags = await this._unitOfWork.Tags
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

            var ebooks = await this._unitOfWork.Ebooks
                        .GetAllQuerable()
                        .Where(e => categories.Any() ? categories.Contains(e.CategoryId) : true)
                        .Where(e => tags.Any() ? e.TagsToEbooks.Select(t => t.TagId).Intersect(tags).Any() : true)
                        .Where(e => teachers.Any() && teachers.Contains(e.CreatorId)? true : false)
                        .Where(e => viewModel.TitleName.Length > 0 ? e.Title.Contains(viewModel.TitleName) : true)
                        .ToListAsync();

            var videos = await this._unitOfWork.Videos
                        .GetAllQuerable()
                        .Where(e => categories.Any() ? categories.Contains(e.CategoryId) : true)
                        .Where(e => tags.Any() ? e.TagsToVideos.Select(t => t.TagId).Intersect(tags).Any() : true)
                        .Where(e => teachers.Any() && teachers.Contains(e.CreatorId)? true : false)
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
        public async Task<IHttpActionResult> GetSubscriptionPackages()
        {
            return Ok(await this._unitOfWork.SubscriptionPackages
                                .GetAllAsync());
        }
        [HttpGet]
        [Route("api/packages/")]
        public async Task<IHttpActionResult> GetSubscriptionPackage(int id)
        {
            return Ok(await this._unitOfWork.SubscriptionPackages.GetAsync(id));
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
        [Route("api/categories")]
        public async Task<IHttpActionResult> GetCategories()
        {
            var categories = await this._unitOfWork.Categories
                                                .GetAllAsync();
            return Ok(categories);
        }
        [HttpGet]
        [Route("api/category")]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            var categories = await this._unitOfWork.Categories
                                                .GetAsync(id);
            return Ok(categories);
        }
        [HttpGet]
        [Route("api/categories/masters")]
        public async Task<IHttpActionResult> GetCategoriesMaster()
        {
            var categories = await this._unitOfWork.Categories
                                                .GetAllQueryable()
                                                .Where(c => c.Master)
                                                .ToListAsync();
            return Ok(categories);
        }
        [HttpGet]
        [Route("api/categories/nomasters")]
        public async Task<IHttpActionResult> GetCategoriesNoMaster()
        {
            var categories = await this._unitOfWork.Categories
                                                .GetAllQueryable()
                                                .Where(c => !c.Master)
                                                .ToListAsync();
            return Ok(categories);
        }
        [HttpGet]
        [Route("api/tags")]
        public async Task<IHttpActionResult> GetTags()
        {
            return Ok(await this._unitOfWork.Tags.GetAllAsync());
        }
        [HttpGet]
        [Route("api/tag")]
        public async Task<IHttpActionResult> GetTag(int id)
        {
            return Ok(await this._unitOfWork.Tags.GetAsync(id));
        }
        [HttpGet]
        [Route("api/users/role")]
        public async Task<IHttpActionResult> GetUsersByRole(string rolename)
        {
            var rolesIds = await this._rolesRepo
                                             .GetAllQuerable()
                                             .Where(r => r.Name.Equals(rolename))
                                             .Select(r => r.Id)
                                             .ToListAsync();
            var users = await this._usersRepo
                                    .GetAllQuerable()
                                    .Where(u => rolesIds.Any() ? u.Roles.Select(r => r.RoleId).Intersect(rolesIds).Any() : false)
                                    .ToListAsync();
            if (users.Count > 0)
                return Ok(users);
            else
                return Ok("null");
        }
        [HttpGet]
        [Route("api/reviews")]
        public async Task<IHttpActionResult> GetReviews()
        {
            return Ok(await this._unitOfWork.Reviews.GetAllAsync());
        }
        [HttpGet]
        [Route("api/review")]
        public async Task<IHttpActionResult> GetReview(int id)
        {
            return Ok(await this._unitOfWork.Reviews.GetAsync(id));
        }
        [HttpGet]
        [Route("api/ebooks")]
        public async Task<IHttpActionResult> GetEbookss()
        {
            return Ok(await this._unitOfWork.Ebooks.GetAllAsync());
        }
        [HttpGet]
        [Route("api/ebook")]
        public async Task<IHttpActionResult> GetEbook(int id)
        {
            return Ok(await this._unitOfWork.Ebooks.GetAsync(id));
        }
        [HttpGet]
        [Route("api/videos")]
        public async Task<IHttpActionResult> GetVideos()
        {
            return Ok(await this._unitOfWork.Videos.GetAllAsync());
        }
        [HttpGet]
        [Route("api/video")]
        public async Task<IHttpActionResult> GetVideo(int id)
        {
            return Ok(await this._unitOfWork.Videos.GetAsync(id));
        }
        [HttpGet]
        [Route("api/contenttypes")]
        public async Task<IHttpActionResult> GetContentTypes()
        {
            return Ok(await this._unitOfWork.ContentTypes.GetAllAsync());
        }
        [HttpGet]
        [Route("api/contenttype")]
        public async Task<IHttpActionResult> GetContentType(int id)
        {
            return Ok(await this._unitOfWork.ContentTypes.GetAsync(id));
        }
        [HttpGet]
        [Route("api/payments")]
        public async Task<IHttpActionResult> GetPayments()
        {
            return Ok(await this._unitOfWork.Payments.GetAllAsync());
        }
        [HttpGet]
        [Route("api/payment")]
        public async Task<IHttpActionResult> GetPayment(int id)
        {
            return Ok(await this._unitOfWork.Payments.GetAsync(id));
        }
    }
}