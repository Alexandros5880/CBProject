using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class SubscriptionPackagesController : Controller
    {
        private SubscriptionPackageRepository _subscriptionRepo;
        private UsersRepo _usersRepo;
        private ContentTypeRepository _contentTypeRepo;
        private PaymentsRepository _peynmentRepo;
        public SubscriptionPackagesController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._subscriptionRepo = unitOfWork.SubscriptionPackages;
            this._usersRepo = (UsersRepo)usersRepo;
            this._contentTypeRepo = unitOfWork.ContentTypes;
            this._peynmentRepo = unitOfWork.Payments;

        }
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            return View(await this._subscriptionRepo.GetAllAsync());
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            var viewModel = new SubscriptionPackageViewModel();
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.OtherContentType = await this._contentTypeRepo.GetAllAsync();
            viewModel.OtherPayment = await this._peynmentRepo.GetAllAsync();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubscriptionPackageViewModel subscriptionPackageViewModel)
        {
            if (ModelState.IsValid)
            {
                var subscriptionPackage = Mapper.Map<SubscriptionPackageViewModel, SubscriptionPackage>(subscriptionPackageViewModel);
                if (subscriptionPackageViewModel.AddUsers != null && subscriptionPackageViewModel.AddUsers.Count > 0)
                {
                    foreach (var userId in subscriptionPackageViewModel.AddUsers)
                    {
                        subscriptionPackage.MyUsers.Add(await this._usersRepo.GetAsync(userId));
                    }
                }
                this._subscriptionRepo.Add(subscriptionPackage);
                await this._subscriptionRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(subscriptionPackageViewModel);
        }
        [Authorize(Roles = "Admin")]
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
            var viewModel = Mapper.Map<SubscriptionPackage, SubscriptionPackageViewModel>(subscriptionPackage);
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.MyUsers = await this._usersRepo
                                            .GetAllQuerable()
                                            .Where(u => !subscriptionPackage.MyUsers.Contains(u))
                                            .ToListAsync();
            viewModel.OtherContentType = await this._contentTypeRepo.GetAllAsync();
            viewModel.OtherPayment = await this._peynmentRepo.GetAllAsync();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubscriptionPackageViewModel subscriptionPackageViewModel)
        {
            if (ModelState.IsValid)
            {
                var subscriptionPackage = Mapper.Map<SubscriptionPackageViewModel, SubscriptionPackage>(subscriptionPackageViewModel);
                this._subscriptionRepo.Update(subscriptionPackage);
                if (subscriptionPackageViewModel.AddUsers != null && subscriptionPackageViewModel.AddUsers.Count > 0)
                {
                    foreach (var userId in subscriptionPackageViewModel.AddUsers)
                    {
                        subscriptionPackage.MyUsers.Add(await this._usersRepo.GetAsync(userId));
                    }
                }
                if (subscriptionPackageViewModel.RemoveUsers != null && subscriptionPackageViewModel.RemoveUsers.Count > 0)
                {
                    foreach (var userId in subscriptionPackageViewModel.RemoveUsers)
                    {
                        subscriptionPackage.MyUsers.Remove(await this._usersRepo.GetAsync(userId));
                    }
                }
                await this._subscriptionRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(subscriptionPackageViewModel);
        }
        [Authorize(Roles = "Admin")]
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
                this._usersRepo.Dispose();
                this._contentTypeRepo.Dispose();
                this._peynmentRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}