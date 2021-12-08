using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

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

        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View(new CategoryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                this._categories.Add(category);
                await this._categories.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(categoryViewModel);
        }

        [Authorize(Roles = "Admin")]
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
            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);
            return View(categoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                this._categories.Update(category);
                await this._categories.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(categoryViewModel);
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
