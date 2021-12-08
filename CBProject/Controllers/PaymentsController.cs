using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModel;
using CBProject.Models.ViewModels;
using CBProject.Repositories.IdentityRepos;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class PaymentsController : Controller
    {
        private PaymentsRepository _paymentsRepo;
        public PaymentsController(IUnitOfWork unitOfWork)
        {
            this._paymentsRepo = unitOfWork.Payments;
        }

        public async Task<ActionResult> Index()
        {
            return View (await _paymentsRepo.GetAllAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await this._paymentsRepo.GetAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        public ActionResult Create()
        {
            return View(new PaymentViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PaymentViewModel paymentViewModel)
        {
            if (ModelState.IsValid)
            {
                var payment = Mapper.Map<PaymentViewModel, Payment>(paymentViewModel);
                this._paymentsRepo.Add(payment);
                await this._paymentsRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(paymentViewModel);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await this._paymentsRepo.GetAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            var paymentViewModel = Mapper.Map<Payment, PaymentViewModel>(payment);
            return View(paymentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PaymentViewModel paymentViewModel)
        {
            if (ModelState.IsValid)
            {
                var payment = Mapper.Map<PaymentViewModel, Payment>(paymentViewModel);
                this._paymentsRepo.Update(payment);
                await this._paymentsRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(paymentViewModel);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = await this._paymentsRepo.GetAsync(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._paymentsRepo.Delete(id);
            await this._paymentsRepo.SaveAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._paymentsRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}