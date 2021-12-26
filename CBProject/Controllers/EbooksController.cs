using AutoMapper;
using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class EbooksController : Controller
    {
        private EbooksRepository _ebooksRepository;
        private CategoriesRepository _categoriesRepository;
        private TagsRepository _tagsRepository;
        private RatingsRepository _ratingsRepository;
        private ReviewsRepository _reviewsRepository;
        private ApplicationDbContext _context;
        private UsersRepo _usersRepo;
        public EbooksController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._categoriesRepository = unitOfWork.Categories;
            this._tagsRepository = unitOfWork.Tags;
            this._ratingsRepository = unitOfWork.Ratings;
            this._reviewsRepository = unitOfWork.Reviews;
            this._context = unitOfWork.Context;
            this._usersRepo = (UsersRepo)usersRepo;

        }
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var ebooks = await this._ebooksRepository.GetAllAsync();
            var categories = await this._categoriesRepository.GetAllAsync();

            List<EbookViewModel> viewModels = new List<EbookViewModel>();
            foreach (var ebook in ebooks)
            {
                var viewModel = Mapper.Map<Ebook, EbookViewModel>(ebook);
                viewModel.Categories = new SelectList(categories, "ID", "Name");
                var users = await this._usersRepo.GetAllAsync();
                viewModel.Users = new SelectList(users, "Id", "FullName");
                viewModel.Category = ebook.Category;
                viewModel.Creator = ebook.Creator;
                viewModel.Rate = await this._ebooksRepository.GetRatingsAverageAsync(ebook.ID);
                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }
        public async Task<ActionResult> PublicDetails(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            Ebook ebook = await this._ebooksRepository.GetAsync(id);
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var viewModel = Mapper.Map<Ebook, EbookViewModel>(ebook);
            return View("PublicDetails", viewModel);
        }
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await this._ebooksRepository.GetAsync(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Ebook, EbookViewModel>(ebook);
            return View(viewModel);
        }
        [Authorize(Roles = "Admin, ContentCreator")]
        public async Task<ActionResult> Create()
        {
            var userId = User.Identity.GetUserId();
            EbookViewModel viewModel = new EbookViewModel();
            var categories = await this._categoriesRepository.GetAllAsync();
            var users = await this._usersRepo.GetAllAsync();
            viewModel.Users = new SelectList(users, "Id", "FullName");
            viewModel.Categories = new SelectList(categories, "ID", "Name");
            viewModel.UploadDate = DateTime.Today;
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EbookViewModel viewModel, HttpPostedFileBase EbookImageFile, HttpPostedFileBase EbookFile)
        {  
            if (ModelState.IsValid)
            {
                // EbookImageFile
                if (EbookImageFile != null)
                {
                    viewModel.EbookImageFile = EbookImageFile;
                    string FileName = Path.GetFileNameWithoutExtension(viewModel.EbookImageFile.FileName);
                    string FileExtension = Path.GetExtension(viewModel.EbookImageFile.FileName);
                    FileName = viewModel.Title.Trim() + FileExtension;
                    viewModel.EbookImagePath = (StaticImfo.EbooksImagesPath + FileName).Trim();
                    viewModel.EbookImageFile.SaveAs(Server.MapPath(viewModel.EbookImagePath));
                }
                // EbookFile
                if (EbookFile != null)
                {
                    viewModel.EbookFile = EbookFile;
                    string FileName = Path.GetFileNameWithoutExtension(viewModel.EbookFile.FileName);
                    string FileExtension = Path.GetExtension(viewModel.EbookFile.FileName);
                    FileName = viewModel.Title.Trim() + FileExtension;
                    viewModel.EbookFilePath = (StaticImfo.EbooksFilesPath + FileName).Trim();
                    viewModel.EbookFile.SaveAs(Server.MapPath(viewModel.EbookFilePath));
                }
                var ebookDB = Mapper.Map<EbookViewModel, Ebook>(viewModel);
                ebookDB.Category = await _categoriesRepository.GetAsync(viewModel.CategoryId);
                this._ebooksRepository.Add(ebookDB);
                await this._ebooksRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [Authorize(Roles = "Admin, ContentCreator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await _ebooksRepository.GetAsync(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            EbookViewModel viewModel = Mapper.Map<Ebook, EbookViewModel>(ebook);
            var categories = await this._categoriesRepository.GetAllAsync();
            viewModel.Categories = new SelectList(categories, "ID", "Name");
            var users = await this._usersRepo.GetAllAsync();
            viewModel.Users = new SelectList(users, "Id", "FullName");
            return View(viewModel);
         
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EbookViewModel viewModel, HttpPostedFileBase EbookImageFile, HttpPostedFileBase EbookFile)
        {
            if (ModelState.IsValid)
            {
                // EbookImageFile
                var imgFile = false;
                if (EbookImageFile != null)
                {
                    viewModel.EbookImageFile = EbookImageFile;
                    string FileName = Path.GetFileNameWithoutExtension(viewModel.EbookImageFile.FileName);
                    string FileExtension = Path.GetExtension(viewModel.EbookImageFile.FileName);
                    FileName = viewModel.Title.Trim() + FileExtension;
                    viewModel.EbookImagePath = (StaticImfo.EbooksImagesPath + FileName).Trim();
                    viewModel.EbookImageFile.SaveAs(Server.MapPath(viewModel.EbookImagePath));
                    imgFile = true;
                }
                // EbookFile
                var file = false;
                if (EbookFile != null)
                {
                    viewModel.EbookFile = EbookFile;
                    string FileName = Path.GetFileNameWithoutExtension(viewModel.EbookFile.FileName);
                    string FileExtension = Path.GetExtension(viewModel.EbookFile.FileName);
                    FileName = viewModel.Title.Trim() + FileExtension;
                    viewModel.EbookFilePath = (StaticImfo.EbooksFilesPath + FileName).Trim();
                    viewModel.EbookFile.SaveAs(Server.MapPath(viewModel.EbookFilePath));
                    file = true;
                }
                var oldImg = (await this._ebooksRepository.GetAsync(viewModel.ID)).EbookImagePath;
                var olfFile = (await this._ebooksRepository.GetAsync(viewModel.ID)).EbookFilePath;
                if (!imgFile) viewModel.EbookImagePath = oldImg;
                else
                {
                    FileInfo img = new FileInfo(HttpRuntime.AppDomainAppPath + oldImg);
                    if (img.Exists)
                    {
                        img.Delete();
                    }
                }
                if (!file) viewModel.EbookFilePath = olfFile;
                else
                {
                    FileInfo f = new FileInfo(HttpRuntime.AppDomainAppPath + olfFile);
                    if (f.Exists)
                    {
                        f.Delete();
                    }
                }
                var ebookDB = Mapper.Map<EbookViewModel, Ebook>(viewModel);
                _context.Entry(ebookDB).State = EntityState.Modified;
                //this._ebooksRepository.Delete(ebookDB.ID);
                //await this._ebooksRepository.SaveAsync();
                //this._ebooksRepository.Add(ebookDB);
                //await this._ebooksRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            
            return View(viewModel);
        }
        [Authorize(Roles = "Admin, ContentCreator")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await _ebooksRepository.GetAsync(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            return View(ebook);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var ebook = await this._ebooksRepository.GetAsync(id);
            FileInfo img = new FileInfo(HttpRuntime.AppDomainAppPath + ebook.EbookImagePath);
            if (img.Exists)
            {
                img.Delete();
            }
            FileInfo f = new FileInfo(HttpRuntime.AppDomainAppPath + ebook.EbookFilePath);
            if (f.Exists)
            {
                f.Delete();
            }
            _ebooksRepository.Delete(id);
            await _ebooksRepository.SaveAsync();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddReview(int ebookId, string comment)
        {
            await this._ebooksRepository.AddReviewAsync(ebookId, User.Identity.GetUserId(), comment);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddTag(int ebookId, string title)
        {
            await this._ebooksRepository.AddTagAsync(ebookId, title);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddRate(int ebookId, float rate)
        {
            await this._ebooksRepository.AddRatingAsync(ebookId, User.Identity.GetUserId(), rate);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._ebooksRepository.Dispose();
                this._categoriesRepository.Dispose();
                this._tagsRepository.Dispose();
                this._ratingsRepository.Dispose();
                this._reviewsRepository.Dispose();
                this._context.Dispose();
                this._usersRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
