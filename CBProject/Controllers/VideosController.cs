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
    public class VideosController : Controller
    {
        private readonly VideosRepository _videoRepo;
        private readonly UsersRepo _usersRepo;
        private readonly CategoriesRepository _categoriesRepo;
        private readonly TagsRepository _tagsRepo;
        private readonly ReviewsRepository _reviewRepo;
        private readonly RatingsRepository _ratingsRepo;
        public VideosController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._videoRepo = unitOfWork.Videos;
            this._usersRepo = (UsersRepo)usersRepo;
            this._categoriesRepo = unitOfWork.Categories;
            this._tagsRepo = unitOfWork.Tags;
            this._reviewRepo = unitOfWork.Reviews;
            this._ratingsRepo = unitOfWork.Ratings;
        }
        public async Task<ActionResult> Index()
        {
            return View(await this._videoRepo.GetAllAsync());
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = await this._videoRepo.GetAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }
        public async Task<ActionResult> Create()
        {
            var viewModel = new VideoViewModel();
            viewModel.OtherTags = await this._tagsRepo.GetAllAsync();
            viewModel.OtherReviews = await this._reviewRepo.GetAllAsync();
            viewModel.OtherRatings = await this._ratingsRepo.GetAllAsync();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VideoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var video = Mapper.Map<VideoViewModel, Video>(viewModel);
                this._videoRepo.Add(video);
                await this._videoRepo.SaveAsync();
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
            Video video = await this._videoRepo.GetAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Video, VideoViewModel>(video);
            viewModel.OtherTags = await this._tagsRepo.GetAllAsync();
            viewModel.OtherReviews = await this._reviewRepo.GetAllAsync();
            viewModel.OtherRatings = await this._ratingsRepo.GetAllAsync();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VideoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var video = Mapper.Map<VideoViewModel, Video>(viewModel);
                this._videoRepo.Update(video);
                await this._videoRepo.SaveAsync();
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
            Video video = await this._videoRepo.GetAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._videoRepo.Delete(id);
            await this._videoRepo.SaveAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._videoRepo.Dispose();
                this._usersRepo.Dispose();
                this._categoriesRepo.Dispose();
                this._tagsRepo.Dispose();
                this._reviewRepo.Dispose();
                this._ratingsRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
