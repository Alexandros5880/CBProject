using CBProject.HelperClasses.Interfaces;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class HomeController : Controller
    {
        private EbooksRepository _ebooksRepository;
        private UsersRepo _usersRepo;
        private CategoriesRepository _categoriesRepo;
       private VideosRepository _videosRepository;
       // private IRepository<Plans> _plansRepository;
        public HomeController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._categoriesRepo = unitOfWork.Categories;
            this._videosRepository = unitOfWork.Videos;
            this._usersRepo = (UsersRepo)usersRepo;
        }
        public async Task<ActionResult> Index(string name)
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Categories = await this._categoriesRepo
                                        .GetAllQueryable()
                                        .Where(c => c.Master == true)
                                        .Where(c => c.Videos.Count > 0)
                                        .Where(c => c.Ebooks.Count > 0)
                                        .ToListAsync();
            if (name == null)
            {
                viewModel.Videos = await this._videosRepository.GetAllAsync();
                viewModel.Ebooks = await this._ebooksRepository.GetAllAsync();
            }
            else
            {
                viewModel.Videos = await this._videosRepository.GetAllByCategoryNameAsync(name);
                viewModel.Ebooks = await this._ebooksRepository.GetAllByCategoryNameAsync(name);
            }
            return View(viewModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }




        public async Task<ActionResult> RenderPartial(string search)
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Categories = await this._categoriesRepo
                                        .GetAllQueryable()
                                        .Where(c => c.Master == true)
                                        .Where(c => c.Videos.Count > 0)
                                        .Where(c => c.Ebooks.Count > 0)
                                        .ToListAsync();
            if ( search == null || search.Length == 0 )
            {
                viewModel.Videos = await this._videosRepository.GetAllAsync();
                viewModel.Ebooks = await this._ebooksRepository.GetAllAsync();
            }
            else
            {
                viewModel.Videos = await this._videosRepository.GetAllByCategoryNameAsync(search);
                viewModel.Ebooks = await this._ebooksRepository.GetAllByCategoryNameAsync(search);
            }
            return View(viewModel);
            return PartialView("_Products");
        }
    }
}