using CBProject.HelperClasses.Interfaces;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
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
        public HomeController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._categoriesRepo = unitOfWork.Categories;
            this._videosRepository = unitOfWork.Videos;
            this._usersRepo = (UsersRepo)usersRepo;
        }
        public async Task<ActionResult> Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.Ebooks = await this._ebooksRepository.GetAllAsync();
           
            return View(viewModel);
        }
        public async Task<ActionResult> About()
        {
            return View();
        }
        public async Task<ActionResult> Contact()
        {
            return View();
        }
        public async Task<ActionResult> Lessons()
        {
            return View();
        }
    }
}