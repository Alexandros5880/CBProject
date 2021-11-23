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

namespace CBProject.Controllers
{
    public class EbooksController : Controller
    {
        private IRepository<Ebook> _ebooksRepository;
        private IRepository<Category> _categoriesRepository;

        public EbooksController(IUnitOfWork unitOfWork)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._categoriesRepository = unitOfWork.Categories;

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

        // GET: Ebooks/Create
        public async Task<ActionResult> Create()
        {
            //ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name");

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
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,Description,Thumbnail,Url,UploadDate,CreatorId,CategoryId")] Ebook ebook)
        {
            if (ModelState.IsValid)
            {
                db.Ebooks.Add(ebook);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", ebook.CategoryId);
            return View(ebook);
        }

        // GET: Ebooks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await db.Ebooks.FindAsync(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", ebook.CategoryId);
            return View(ebook);
        }

        // POST: Ebooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,Description,Thumbnail,Url,UploadDate,CreatorId,CategoryId")] Ebook ebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ebook).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", ebook.CategoryId);
            return View(ebook);
        }

        // GET: Ebooks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await db.Ebooks.FindAsync(id);
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
            Ebook ebook = await db.Ebooks.FindAsync(id);
            db.Ebooks.Remove(ebook);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
