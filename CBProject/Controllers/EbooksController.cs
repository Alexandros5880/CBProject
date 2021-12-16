using AutoMapper;
using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
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
        public EbooksController(IUnitOfWork unitOfWork)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._categoriesRepository = unitOfWork.Categories;
            this._tagsRepository = unitOfWork.Tags;
            this._ratingsRepository = unitOfWork.Ratings;
            this._reviewsRepository = unitOfWork.Reviews;
            this._context = unitOfWork.Context;

        }
        public async Task<ActionResult> Index()
        {
            var ebooks = await this._ebooksRepository.GetAllAsync();
            var categories = await this._categoriesRepository.GetAllAsync();

            List<EbookViewModel> viewModels = new List<EbookViewModel>();
            foreach (var ebook in ebooks)
            {
                viewModels.Add(Mapper.Map<Ebook, EbookViewModel>(ebook));
                viewModels.FirstOrDefault(b => b.ID == ebook.ID).Categories = new SelectList(categories, "ID", "Name");
                viewModels.FirstOrDefault(b => b.ID == ebook.ID).MyTags = await this._tagsRepository.GetAllFromEbookAsync(ebook);
                viewModels.FirstOrDefault(b => b.ID == ebook.ID).MyReviews = await this._reviewsRepository.GetAllFromEbookAsync(ebook);
                viewModels.FirstOrDefault(b => b.ID == ebook.ID).MyRatings = await this._ratingsRepository.GetAllFromEbookAsync(ebook);
                viewModels.FirstOrDefault(b => b.ID == ebook.ID).OtherTags = await this._tagsRepository.GetAllOtherFromEbookAsync(ebook);
                viewModels.FirstOrDefault(b => b.ID == ebook.ID).OtherReviews = await this._reviewsRepository.GetAllOtherFromEbookAsync(ebook);
                viewModels.FirstOrDefault(b => b.ID == ebook.ID).OtherRatings = await this._ratingsRepository.GetAllOtherFromEbookAsync(ebook);
            }
            return View(viewModels);
        }
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
            viewModel.MyTags = await this._tagsRepository.GetAllFromEbookAsync(ebook);
            viewModel.MyReviews = await this._reviewsRepository.GetAllFromEbookAsync(ebook);
            viewModel.MyRatings = await this._ratingsRepository.GetAllFromEbookAsync(ebook);
            return View(viewModel);
        }
        [Authorize(Roles = "Admin, ContentCreator")]
        public async Task<ActionResult> Create()
        {
            var userId = User.Identity.GetUserId();
            EbookViewModel viewModel = new EbookViewModel();
            var categories = await this._categoriesRepository.GetAllAsync();
            viewModel.OtherTags = await this._tagsRepository.GetAllAsync();
            viewModel.OtherReviews = await this._reviewsRepository.GetAllAsync();
            viewModel.OtherRatings = await this._ratingsRepository.GetAllAsync();
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
                    FileName = FileName.Trim() + FileExtension;
                    viewModel.EbookImagePath = StaticImfo.EbooksImagesPath + " " + viewModel.Title;
                    viewModel.EbookImageFile.SaveAs(Server.MapPath(viewModel.EbookImagePath));
                }
                // EbookFile
                if (EbookFile != null)
                {
                    viewModel.EbookFile = EbookFile;
                    string FileName = Path.GetFileNameWithoutExtension(viewModel.EbookFile.FileName);
                    string FileExtension = Path.GetExtension(viewModel.EbookFile.FileName);
                    FileName = FileName.Trim() + FileExtension;
                    viewModel.EbookFilePath = StaticImfo.EbooksFilesPath + " " + viewModel.Title;
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
            viewModel.OtherTags = await this._tagsRepository.GetAllOtherFromEbookAsync(ebook);
            viewModel.OtherReviews = await this._reviewsRepository.GetAllOtherFromEbookAsync(ebook);
            viewModel.OtherRatings = await this._ratingsRepository.GetAllOtherFromEbookAsync(ebook);
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
                    FileName = FileName.Trim() + FileExtension;
                    viewModel.EbookImagePath = StaticImfo.EbooksImagesPath + " " + viewModel.Title;
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
                    FileName = FileName.Trim() + FileExtension;
                    viewModel.EbookFilePath = StaticImfo.EbooksFilesPath + " " + viewModel.Title;
                    viewModel.EbookFile.SaveAs(Server.MapPath(viewModel.EbookFilePath));
                    file = true;
                }
                var oldImg = (await this._ebooksRepository.GetAsync(viewModel.ID)).EbookImagePath;
                var olfFile = (await this._ebooksRepository.GetAsync(viewModel.ID)).EbookFilePath;
                if (!imgFile) viewModel.EbookImagePath = oldImg;
                if (!file) viewModel.EbookFilePath = olfFile;
                var ebookDB = Mapper.Map<EbookViewModel, Ebook>(viewModel);
               _context.Entry(ebookDB).State = EntityState.Modified;
                await _ebooksRepository.SaveAsync();
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
            _ebooksRepository.Delete(id);
            await _ebooksRepository.SaveAsync();
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
            }
            base.Dispose(disposing);
        }
    }
}
