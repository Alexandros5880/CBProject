﻿using CBProject.HelperClasses.Interfaces;
using CBProject.Models.ViewModels;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
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
        public async Task<IHttpActionResult> GetSearchByFilters(FilterParams filters)
        {
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