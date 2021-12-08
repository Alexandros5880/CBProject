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
    public class SubscriptionPackagesController : Controller
    {
        private SubscriptionPackageRepository _subscriptionRepo;
        public SubscriptionPackagesController(IUnitOfWork unitOfWork)
        {
            this._subscriptionRepo = unitOfWork.SubscriptionPackages;
        }

        public async Task<ActionResult> Index()
        {
            return View(await this._subscriptionRepo.GetAllAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionPackage subscriptionPackage = await this._subscriptionRepo.GetAsync(id);
            if (subscriptionPackage == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionPackage);
        }

        public ActionResult Create()
        {
            return View(new SubscriptionPackageViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubscriptionPackageViewModel subscriptionPackageViewModel)
        {
            if (ModelState.IsValid)
            {
                var subscriptionPackage = Mapper.Map<SubscriptionPackageViewModel, SubscriptionPackage>(subscriptionPackageViewModel);
                this._subscriptionRepo.Add(subscriptionPackage);
                await this._subscriptionRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(subscriptionPackageViewModel);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionPackage subscriptionPackage = await this._subscriptionRepo.GetAsync(id);
            if (subscriptionPackage == null)
            {
                return HttpNotFound();
            }
            var subscriptionPackageViewModel = Mapper.Map<SubscriptionPackage, SubscriptionPackageViewModel>(subscriptionPackage);
            return View(subscriptionPackageViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubscriptionPackageViewModel subscriptionPackageViewModel)
        {
            if (ModelState.IsValid)
            {
                var subscriptionPackage = Mapper.Map<SubscriptionPackageViewModel, SubscriptionPackage>(subscriptionPackageViewModel);
                this._subscriptionRepo.Update(subscriptionPackage);
                await this._subscriptionRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(subscriptionPackageViewModel);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionPackage subscriptionPackage = await this._subscriptionRepo.GetAsync(id);
            if (subscriptionPackage == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionPackage);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._subscriptionRepo.Delete(id);
            await this._subscriptionRepo.SaveAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._subscriptionRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}