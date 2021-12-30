using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.HelperModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
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
        // GET api/<controller>
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
        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(string search)
        {
            if (search == null)
                return NotFound();
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
        public async Task<IHttpActionResult> GetContentsByCategoryId(int? id)
        {
            if (id == null)
                return NotFound();
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
            if (name == null)
                return NotFound();
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
        public async Task<IHttpActionResult> GetSearchByFilters(FilterParams filters)
        {
            if (filters == null)
                return NotFound();
            var products = await this._unitOfWork.Categories.GetSearchByFiltersAsync(filters);
            return Ok(products);
        }
        [HttpGet]
        [Route("api/products/packages")]
        public async Task<IHttpActionResult> GetSubscriptionPackages()
        {
            return Ok(await this._unitOfWork.SubscriptionPackages
                                .GetAllAsync());
        }
        [HttpGet]
        [Route("api/packages/{id}")]
        public async Task<IHttpActionResult> GetSubscriptionPackage(int? id)
        {
            if (id == null)
                return NotFound();
            SubscriptionPackage package = await this._unitOfWork.SubscriptionPackages.GetAsync(id);
            if (package == null)
                return NotFound();
            return Ok(package);
        }
        [HttpGet]
        [Route("api/user")]
        public async Task<IHttpActionResult> GetUser(string userId)
        {
            if (userId == null)
                return NotFound();
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
        public async Task<IHttpActionResult> GetCategory(int? id)
        {
            if (id == null)
                return NotFound();
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
        public async Task<IHttpActionResult> GetTag(int? id)
        {
            if (id == null)
                return NotFound();
            return Ok(await this._unitOfWork.Tags.GetAsync(id));
        }
        [HttpGet]
        [Route("api/users/role")]
        public async Task<IHttpActionResult> GetUsersByRole(string rolename)
        {
            if (rolename == null)
                return NotFound();
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
        public async Task<IHttpActionResult> GetReview(int? id)
        {
            if (id == null)
                return NotFound();
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
        public async Task<IHttpActionResult> GetEbook(int? id)
        {
            if (id == null)
                return NotFound();
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
        public async Task<IHttpActionResult> GetVideo(int? id)
        {
            if (id == null)
                return NotFound();
            return Ok(await this._unitOfWork.Videos.GetAsync(id));
        }
        [HttpGet]
        [Route("api/payments")]
        public async Task<IHttpActionResult> GetPayments()
        {
            return Ok(await this._unitOfWork.Payments.GetAllAsync());
        }
        [HttpGet]
        [Route("api/payment")]
        public async Task<IHttpActionResult> GetPayment(int? id)
        {
            if (id == null)
                return NotFound();
            return Ok(await this._unitOfWork.Payments.GetAsync(id));
        }

        [HttpPost]
        [Route("api/ebook/requarements/add/{id}")]
        public async Task<IHttpActionResult> AddEbookRequarement(int? id, AddRequirement requirement)
        {
            if (id == null)
                return NotFound();
            if (requirement == null)
                return NotFound();
            await this._unitOfWork.Ebooks.AddRequirementAsync(id, requirement.Content);
            return Ok();
        }
        [HttpGet]
        [Route("api/ebook/requarements/remove/{ebookId}/{requirementId}")]
        public async Task<IHttpActionResult> RemoveEbookRequarement(int? ebookId, int? requirementId)
        {
            if (ebookId == null)
                return NotFound();
            if (requirementId == null)
                return NotFound();
            await this._unitOfWork.Ebooks.RemoveRequirementAsync(ebookId, requirementId);
            return Ok();
        }
        [HttpPost]
        [Route("api/video/requarements/add/{id}")]
        public async Task<IHttpActionResult> AddVideoRequarement(int? id, AddRequirement requirement)
        {
            if (id == null)
                return NotFound();
            if (requirement == null)
                return NotFound();
            await this._unitOfWork.Videos.AddRequirementAsync(id, requirement.Content);
            return Ok();
        }
        [HttpGet]
        [Route("api/video/requarements/remove/{videoId}/{requirementId}")]
        public async Task<IHttpActionResult> RemoveVideoRequarement(int? videoId, int? requirementId)
        {
            if (videoId == null)
                return NotFound();
            if (requirementId == null)
                return NotFound();
            await this._unitOfWork.Videos.RemoveRequirementAsync(videoId, requirementId);
            return Ok();
        }

        [HttpPost]
        [Route("api/order/new")]
        public async Task<IHttpActionResult> CreateOrder([FromBody] OrderApiModel order)
        {
            ApplicationUser user = await this._usersRepo.GetByEmailAsync(order.UserEmail);
            SubscriptionPackage package = await this._unitOfWork.SubscriptionPackages.GetAsync(order.SubscriptionId);
            Order newOrder = new Order()
            {
                UserId = user.Id,
                SubscriptionPackageId = package.ID,
                IsClose = false,
                CreatedDate = DateTime.Today
            };
            this._unitOfWork.Orders.Add(newOrder);
            await this._unitOfWork.Orders.SaveAsync();
            Order orderDB = await this._unitOfWork.Orders.GetAsync(user.Id, package.ID);
            return Ok(orderDB);
        }
    }
}