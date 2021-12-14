using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Ebook> _ebooksRepository;
        //private IRepository<Video> _videosRepository;
       // private IRepository<Plans> _plansRepository;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
           // this._videosRepository = unitOfWork.Videos;
            //this._plansRepository = unitOfWork.Plans;

        }
        public async Task<ActionResult> Index()
        {
            try
            {
                var user = User.Identity.GetUserId(); // TODO:  Adoni des auto edw doulevei
                ViewBag.User = user;
            }
            catch (Exception ex)
            {

            }
            HomeViewModel viewModel = new HomeViewModel()
            {
                //Ebooks = await this._ebooksRepository.GetAllAsync()
            };

            if ( User.IsInRole("Admin") )
            {
                return RedirectToAction("Index", "Users");
            } else
            {
                return View(viewModel);
            }
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
    }
}