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
    public class ReviewsController : Controller
    {
        private readonly ReviewsRepository _reviewRepo;
        private readonly UsersRepo _usersRepo;
        private readonly VideosRepository _videoRepo;
        public ReviewsController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._reviewRepo = unitOfWork.Reviews;
            this._usersRepo = (UsersRepo)usersRepo;
            this._videoRepo = unitOfWork.Videos;
        }
        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = await this._reviewRepo.GetAsync(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }
        public ActionResult Create()
        {
            var viewModel = new ReviewViewModel();
            viewModel.Users = new SelectList(this._usersRepo.GetAll(), "ID", "FullName");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReviewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var review = Mapper.Map<ReviewViewModel, Review>(viewModel);
                this._reviewRepo.Add(review);
                await this._reviewRepo.SaveAsync();
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
            Review review = await this._reviewRepo.GetAsync(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Review, ReviewViewModel>(review);
            viewModel.Users = new SelectList(this._usersRepo.GetAll(), "ID", "FullName");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReviewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var review = Mapper.Map<ReviewViewModel, Review>(viewModel);
                this._reviewRepo.Update(review);
                await this._reviewRepo.SaveAsync();
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
            Review review = await this._reviewRepo.GetAsync(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._reviewRepo.Delete(id);
            await this._reviewRepo.SaveAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._reviewRepo.Dispose();
                this._usersRepo.Dispose();
                this._videoRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
