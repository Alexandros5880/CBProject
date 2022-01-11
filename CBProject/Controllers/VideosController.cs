using AutoMapper;
using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
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
        private RequirementsRepository _requirementsRepo;
        public VideosController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._videoRepo = unitOfWork.Videos;
            this._usersRepo = (UsersRepo)usersRepo;
            this._categoriesRepo = unitOfWork.Categories;
            this._tagsRepo = unitOfWork.Tags;
            this._reviewRepo = unitOfWork.Reviews;
            this._ratingsRepo = unitOfWork.Ratings;
            this._requirementsRepo = unitOfWork.Requirements;
        }
        [Authorize]
        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> PublicDetails(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            Video video = await this._videoRepo.GetAsync(id);
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var viewModel = Mapper.Map<Video, VideoViewModel>(video);
            List<Rating> ratings = (List<Rating>)await this._ratingsRepo.GetAllFromVideoAsync(video);
            float sum = 0.0f;
            foreach (var rating in ratings)
            {
                sum += rating.Rate;
            }
            viewModel.Rate = sum / ratings.Count;
            viewModel.Requirements = await this._videoRepo.GetRequirementsAsync(id);
            var videoPath = Server.MapPath($"~{viewModel.VideoPath}");
            viewModel.Duration = VideoEditor.Duration(videoPath);
            return View("PublicDetails", viewModel);
        }
        [Authorize]
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
            var viewModel = Mapper.Map<Video, VideoViewModel>(video);
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherCategory = await this._categoriesRepo.GetAllAsync();
            viewModel.Requirements = await this._videoRepo.GetRequirementsAsync(video.ID);
            return View(viewModel);
        }
        public async Task<ActionResult> Create()
        {
            var viewModel = new VideoViewModel();
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherCategory = await this._categoriesRepo.GetAllAsync();
            viewModel.UploadDate = DateTime.Today;
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VideoViewModel viewModel, HttpPostedFileBase VideoImageFile, HttpPostedFileBase VideoFile)
        {
            if (ModelState.IsValid)
            {
                // VideoImageFile
                if (VideoImageFile != null)
                {
                    viewModel.VideoImageFile = VideoImageFile;
                    string FileName = Path.GetFileNameWithoutExtension(VideoFile.FileName);
                    string FileExtension = Path.GetExtension(viewModel.VideoImageFile.FileName);
                    FileName = FileName + FileExtension;
                    viewModel.VideoImagePath = (StaticImfo.VideoImagePath + FileName).Trim();
                    viewModel.VideoImageFile.SaveAs(Server.MapPath(viewModel.VideoImagePath));
                }
                // VideoFile
                if (VideoFile != null)
                {
                    viewModel.VideoFile = VideoFile;
                    string FileName = Path.GetFileNameWithoutExtension(VideoFile.FileName);
                    string FileExtension = Path.GetExtension(viewModel.VideoFile.FileName);
                    FileName = FileName + FileExtension;
                    viewModel.VideoPath = (StaticImfo.VideoPath + FileName).Trim();
                    viewModel.VideoFile.SaveAs(Server.MapPath(viewModel.VideoPath));
                }
                var video = Mapper.Map<VideoViewModel, Video>(viewModel);
                this._videoRepo.Add(video);
                await this._videoRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [Authorize]
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
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherCategory = await this._categoriesRepo.GetAllAsync();
            viewModel.Requirements = await this._videoRepo.GetRequirementsAsync(video.ID);
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VideoViewModel viewModel, HttpPostedFileBase VideoImageFile, HttpPostedFileBase VideoFile)
        {
            if (ModelState.IsValid)
            {
                // VideoImageFile
                var imgFile = false;
                if (VideoImageFile != null)
                {
                    viewModel.VideoImageFile = VideoImageFile;
                    string FileName = Path.GetFileNameWithoutExtension(VideoImageFile.FileName);
                    string FileExtension = Path.GetExtension(VideoImageFile.FileName);
                    FileName = FileName + FileExtension;
                    viewModel.VideoImagePath = (StaticImfo.VideoImagePath + FileName).Trim();
                    viewModel.VideoImageFile.SaveAs(Server.MapPath(viewModel.VideoImagePath));
                    imgFile = true;
                }
                // VideoFile
                var videoFile = false;
                if (VideoFile != null)
                {
                    viewModel.VideoFile = VideoFile;
                    string FileName = Path.GetFileNameWithoutExtension(VideoFile.FileName);
                    string FileExtension = Path.GetExtension(VideoFile.FileName);
                    FileName = FileName + FileExtension;
                    viewModel.VideoPath = (viewModel.VideoPath = StaticImfo.VideoPath + FileName).Trim();
                    viewModel.VideoFile.SaveAs(Server.MapPath(viewModel.VideoPath));
                    videoFile = true;
                }
                var imgFileOld = (await this._videoRepo.GetAsync(viewModel.ID)).VideoImagePath;
                var vidFileOld = (await this._videoRepo.GetAsync(viewModel.ID)).VideoPath;
                if (!imgFile) viewModel.VideoImagePath = imgFileOld;
                else
                {
                    FileInfo img = new FileInfo(HttpRuntime.AppDomainAppPath + imgFileOld);
                    if (img.Exists)
                    {
                        img.Delete();
                    }
                }
                if (!videoFile) viewModel.VideoPath = vidFileOld;
                else
                {
                    FileInfo file = new FileInfo(HttpRuntime.AppDomainAppPath + vidFileOld);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                var video = Mapper.Map<VideoViewModel, Video>(viewModel);
                video.UploadDate = viewModel.UploadDate;
                await this._videoRepo.UpdateAsync(video);
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
            var video = await this._videoRepo.GetAsync(id);
            FileInfo img = new FileInfo(HttpRuntime.AppDomainAppPath + video.VideoImagePath);
            if (img.Exists)
            {
                img.Delete();
            }
            FileInfo file = new FileInfo(HttpRuntime.AppDomainAppPath + video.VideoPath);
            if (file.Exists)
            {
                file.Delete();
            }
            this._videoRepo.Delete(id);
            await this._videoRepo.SaveAsync();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddReview(int videoId, string comment)
        {
            await this._videoRepo.AddReviewAsync(videoId, User.Identity.GetUserId(), comment);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddTag(int videoId, string title)
        {
            await this._videoRepo.AddTagAsync(videoId, title);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddRate(int videoId, float rate)
        {
            await this._videoRepo.AddRatingAsync(videoId, User.Identity.GetUserId(), rate);
            return RedirectToAction("Index");
        }
        // Partial Views
        [Authorize]
        public async Task<ActionResult> _Details(int? id)
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
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherCategory = await this._categoriesRepo.GetAllAsync();
            viewModel.Requirements = await this._videoRepo.GetRequirementsAsync(video.ID);
            return PartialView("_Details", viewModel);
        }
        [Authorize]
        public async Task<ActionResult> _Edit(int? id)
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
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherCategory = await this._categoriesRepo.GetAllAsync();
            viewModel.Requirements = await this._videoRepo.GetRequirementsAsync(video.ID);
            return PartialView("_Edit", viewModel);
        }
        [Authorize]
        public async Task<ActionResult> _Delete(int? id)
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
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherCategory = await this._categoriesRepo.GetAllAsync();
            viewModel.Requirements = await this._videoRepo.GetRequirementsAsync(video.ID);
            return PartialView("_Delete", viewModel);
        }
        [Authorize]
        public async Task<ActionResult> _Review(int? id)
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
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherCategory = await this._categoriesRepo.GetAllAsync();
            viewModel.Requirements = await this._videoRepo.GetRequirementsAsync(video.ID);
            return PartialView("_Review", viewModel);
        }
        [Authorize]
        public async Task<ActionResult> _Tag(int? id)
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
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherCategory = await this._categoriesRepo.GetAllAsync();
            viewModel.Requirements = await this._videoRepo.GetRequirementsAsync(video.ID);
            return PartialView("_Tag", viewModel);
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
                this._requirementsRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
