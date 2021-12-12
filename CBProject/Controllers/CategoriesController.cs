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
        public async Task<ActionResult> Create()
        {
            var viewModel = new CategoryViewModel();
            var category = Mapper.Map<CategoryViewModel, Category>(viewModel);
            viewModel.OtherCategories = await _categories.GetOtherAllAsync(category.ID);
            viewModel.MyCategories = await _categories.GetMyAllAsync(category.ID);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  // TODO: Categories Controller Fix Post Create
        public async Task<ActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                //category.Categories = categoryViewModel.MyCategories;
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
            var viewModel = Mapper.Map<Category, CategoryViewModel>(category);
            viewModel.OtherCategories = await _categories.GetOtherAllAsync(category.ID);
            viewModel.MyCategories = await _categories.GetMyAllAsync(category.ID);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // TODO: Categories Controller Fix Post Edit
        public async Task<ContentResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = Mapper.Map<CategoryViewModel, Category>(categoryViewModel);
                //if (categoryViewModel.AddCategories != null && categoryViewModel.AddCategories.Count > 0)
                //{
                //    foreach (int id in categoryViewModel.AddCategories)
                //    {
                //        category.Categories.Add(await this._categories.GetAsync(id));
                //    }
                //}
                //if (categoryViewModel.RemoveCategories != null && categoryViewModel.RemoveCategories.Count > 0)
                //{
                //    foreach (int id in categoryViewModel.RemoveCategories)
                //    {
                //        category.Categories.Remove(await this._categories.GetAsync(id));
                //    }
                //}
                this._categories.Update(category);
                await this._categories.SaveAsync();
                //return RedirectToAction("Index");
                return Content(category.CategoriesToCategories.Count.ToString());
            }
            //return View(categoryViewModel);
            return Content("Error");
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
