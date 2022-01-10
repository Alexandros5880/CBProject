using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class TagsController : Controller
    {
        private readonly TagsRepository _tagsRepo;
        private readonly VideosRepository _videoRepo;
        public TagsController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._tagsRepo = unitOfWork.Tags;
            this._videoRepo = unitOfWork.Videos;
        }
        public async Task<ActionResult> Index()
        {
            return View();
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = await this._tagsRepo.GetAsync(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }
        public ActionResult Create()
        {
            var viewModel = new TagViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = Mapper.Map<TagViewModel, Tag>(viewModel);
                this._tagsRepo.Add(tag);
                await this._tagsRepo.SaveAsync();
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
            Tag tag = await this._tagsRepo.GetAsync(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Tag, TagViewModel>(tag);
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = Mapper.Map<TagViewModel, Tag>(viewModel);
                this._tagsRepo.Update(tag);
                await this._tagsRepo.SaveAsync();
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
            Tag tag = await this._tagsRepo.GetAsync(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._tagsRepo.Delete(id);
            await this._tagsRepo.SaveAsync();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._tagsRepo.Dispose();
                this._videoRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
