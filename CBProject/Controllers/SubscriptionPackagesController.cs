using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class SubscriptionPackagesController : Controller
    {
        private readonly SubscriptionPackageRepository _subscriptionRepo;
        private readonly OrdersRepository _ordersRepository;
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;
        private readonly PaymentsRepository _peynmentRepo;
        private readonly UsersSubscriptionPackagesRepo _userSubscriptionPackageRepository;
        private readonly HelperClasses.EmailService _email;

        public SubscriptionPackagesController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo, HelperClasses.IEmailService email)
        {
            this._subscriptionRepo = unitOfWork.SubscriptionPackages;
            this._usersRepo = (UsersRepo)usersRepo;
            this._rolesRepo = (RolesRepo)rolesRepo;
            this._peynmentRepo = unitOfWork.Payments;
            this._ordersRepository = unitOfWork.Orders;
            this._userSubscriptionPackageRepository = unitOfWork.UserSubscriptionPackages;
            this._email = (HelperClasses.EmailService)email;
        }
        public async Task<ActionResult> Index()
        {
            return View(await this._subscriptionRepo.GetAllAsync());
        }
        public async Task<ActionResult> Subscribe()
        {
            return View();
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            SubscriptionPackage subscriptionPackage = await this._subscriptionRepo.GetAsync(id);
            if (subscriptionPackage == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionPackage);
        }
        public async Task<ActionResult> Create()
        {
            var viewModel = new SubscriptionPackageViewModel();
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
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
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            SubscriptionPackage subscriptionPackage = await this._subscriptionRepo.GetAsync(id);
            if (subscriptionPackage == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<SubscriptionPackage, SubscriptionPackageViewModel>(subscriptionPackage);
            viewModel.OtherUsers = await this._usersRepo.GetAllAsync();
            viewModel.MyUsers = await this._usersRepo
                                            .GetAllQueryable()
                                            .Where(u => !subscriptionPackage.MyUsers.Contains(u))
                                            .ToListAsync();
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
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
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
        public async Task<ActionResult> AfterPayment(int? paymentId, int? orderId)
        {
            if (paymentId == null)
                return HttpNotFound();
            if (orderId == null)
                return HttpNotFound();

            // Get Payment And Payments User
            var payment = await this._peynmentRepo.GetAsync(paymentId);
            var user = await this._usersRepo.GetUserAsyncMainContext(payment.UserId);
            var order = await this._ordersRepository.GetAsync(orderId);
            var package = await this._subscriptionRepo.GetAsync(order.SubscriptionPackageId);

            // Remove old Subsciption Package from user
            var userSabsIds = await this._userSubscriptionPackageRepository
                                                    .GetAllQueryable()
                                                    .Where(u => u.UserId == user.Id)
                                                    .Select(u => u.SubscriptionPackageId)
                                                    .ToListAsync();
            if(userSabsIds.Count > 0)
            {
                foreach (var id in userSabsIds)
                {
                    await this._userSubscriptionPackageRepository.DeleteAsync(id);
                }
            }

            // Add Subscription Package to User
            UserSubscriptionPackage userPackage = new UserSubscriptionPackage()
            {
                UserId = user.Id,
                SubscriptionPackageId = package.ID
            };
            this._userSubscriptionPackageRepository.Add(userPackage);
            await this._userSubscriptionPackageRepository.SaveAsync();

            // Add Student Role
            var studentRole = await this._rolesRepo.GetByNameAsync("Student");
            var guestRole = await this._rolesRepo.GetByNameAsync("Guest");
            this._usersRepo.AddRole(user, studentRole);
            this._usersRepo.RemoveRole(user, guestRole);

            // Send Email
            await this._email.SendEmailReceipt(user);
            return RedirectToAction("Index", "Home");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._subscriptionRepo.Dispose();
                this._usersRepo.Dispose();
                this._rolesRepo.Dispose();
                this._peynmentRepo.Dispose();
                this._ordersRepository.Dispose();
                this._userSubscriptionPackageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}