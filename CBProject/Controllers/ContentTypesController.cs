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
    public class ContentTypesController : Controller
    {
        private ContentTypeRepository _contentType;
        public ContentTypesController(IUnitOfWork unitOfWork)
        {
            this._contentType = unitOfWork.ContentTypes;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _contentType.GetAllAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentType contentType = await this._contentType.GetAsync(id);
            if (contentType == null)
            {
                return HttpNotFound();
            }
            return View(contentType);
        }

        public ActionResult Create()
        {
            return View(new ContentTypeViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContentTypeViewModel contentTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var contentType = Mapper.Map<ContentTypeViewModel, ContentType>(contentTypeViewModel);
                this._contentType.Add(contentType);
                await this._contentType.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(contentTypeViewModel);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentType contentType = await this._contentType.GetAsync(id);
            if (contentType == null)
            {
                return HttpNotFound();
            }
            var contentTypeViewModel = Mapper.Map<ContentType, ContentTypeViewModel>(contentType);
            return View(contentTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContentTypeViewModel contentTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var contentType = Mapper.Map<ContentTypeViewModel, ContentType>(contentTypeViewModel);
                this._contentType.Update(contentType);
                await this._contentType.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(contentTypeViewModel);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentType contentType = await this._contentType.GetAsync(id);
            if (contentType == null)
            {
                return HttpNotFound();
            }
            return View(contentType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._contentType.Delete(id);
            await this._contentType.SaveAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._contentType.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
