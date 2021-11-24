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

namespace CBProject.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoriesRepository _categories;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            this._categories = unitOfWork.Categories;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _categories.GetAllAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await this._categories.GetAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Master")] Category category)
        {
            if (ModelState.IsValid)
            {
                this._categories.Add(category);
                await this._categories.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // TODO: View Model(Related records: categories, videos)
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await this._categories.GetAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // TODO: View Model(Related records: categories, videos)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Master")] Category category)
        {
            if (ModelState.IsValid)
            {
                this._categories.Update(category);
                await this._categories.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await this._categories.GetAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._categories.Delete(id);
            await this._categories.SaveAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._categories.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
