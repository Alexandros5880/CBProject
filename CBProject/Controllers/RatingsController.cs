using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class RatingsController : Controller
    {
        private readonly RatingsRepository _ratingsRepo;
        private readonly UsersRepo _usersRepo;
        private readonly VideosRepository _videoRepo;
        public RatingsController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._ratingsRepo = unitOfWork.Ratings;
            this._usersRepo = (UsersRepo)usersRepo;
            this._videoRepo = unitOfWork.Videos;
        }
        public async Task<ActionResult> Index()
        {
            return View(await this._ratingsRepo.GetAllAsync());
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = await this._ratingsRepo.GetAsync(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }
        public ActionResult Create()
        {
            var viewModel = new RatingViewModel();
            viewModel.Users = new SelectList(this._usersRepo.GetAll(), "ID", "FullName");
            viewModel.Videos = new SelectList(this._videoRepo.GetAll(), "ID", "Title");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RatingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var rating = Mapper.Map<RatingViewModel, Rating>(viewModel);
                this._ratingsRepo.Add(rating);
                await this._ratingsRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = await this._ratingsRepo.GetAsync(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Rating, RatingViewModel>(rating);
            viewModel.Users = new SelectList(this._usersRepo.GetAll(), "ID", "FullName");
            viewModel.Videos = new SelectList(this._videoRepo.GetAll(), "ID", "Title");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RatingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var rating = Mapper.Map<RatingViewModel, Rating>(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = await this._ratingsRepo.GetAsync(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._ratingsRepo.Delete(id);
            await this._ratingsRepo.SaveAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._ratingsRepo.Dispose();
                this._usersRepo.Dispose();
                this._videoRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
