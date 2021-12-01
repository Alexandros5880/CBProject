using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.HelperClasses.Interfaces;
using CBProject.Repositories;
using CBProject.Repositories.Interfaces;
using CBProject.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNet.Identity;

namespace CBProject.Controllers
{
    public class EbooksController : Controller
    {
        private IRepository<Ebook> _ebooksRepository;
        private IRepository<Category> _categoriesRepository;
        private ApplicationDbContext _context;

        public EbooksController(IUnitOfWork unitOfWork)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._categoriesRepository = unitOfWork.Categories;
            this._context = unitOfWork.Context;

        }

        // GET: Ebooks
        public async Task<ActionResult> Index()
        {
            var ebooks = await this._ebooksRepository.GetAllAsync();
            return View(ebooks);
        }

        // GET: Ebooks/Details/5
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
            return View(ebook);
        }

        //[Role("")]
        // GET: Ebooks/Create
        [Authorize(Roles = "Admin, ContentCreator")]
        public async Task<ActionResult> Create()
        {
            //ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name");
            var userId = User.Identity.GetUserId();
            EbookViewModel viewModel = new EbookViewModel();
            var categories = await this._categoriesRepository.GetAllAsync();
           
            viewModel.Categories = new SelectList(categories, "ID", "Name");
            return View(viewModel);
        }

        // POST: Ebooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EbookViewModel ebook)
        {  
            if (ModelState.IsValid)

            {
                var ebookDB = Mapper.Map<EbookViewModel, Ebook>(ebook);
                ebookDB.Category = await _categoriesRepository.GetAsync(ebook.CategoryId);
                this._ebooksRepository.Add(ebookDB);
                await this._ebooksRepository.SaveAsync();
                return RedirectToAction("Index");
            }
        
            return View(ebook);
        }

        // GET: Ebooks/Edit/5
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
            return View(viewModel);
         
        }

        // POST: Ebooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EbookViewModel ebook)
        {
            if (ModelState.IsValid)
            {
                var ebookDB = Mapper.Map<EbookViewModel, Ebook>(ebook);
               _context.Entry(ebookDB).State = EntityState.Modified;
                await _ebooksRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            
            return View(ebook);
        }

        // GET: Ebooks/Delete/5
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

        // POST: Ebooks/Delete/5
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
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
