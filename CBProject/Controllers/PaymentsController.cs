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
using CBProject.Models.EntityModel;
using CBProject.Repositories.IdentityRepos;
using CBProject.HelperClasses.Interfaces;

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
            return View();
        }

        // TODO: View Model(Related records: payments, EnumPaymentMethod)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,PaymentMethods,Price,Tax,Discount")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                this._paymentsRepo.Add(payment);
                await this._paymentsRepo.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(payment);
        }

        // TODO: View Model(Related records: payments, EnumPaymentMethod)
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
            return View(payment);
        }

        // TODO: View Model(Related records: payments, EnumPaymentMethod)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,PaymentMethods,Price,Tax,Discount")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                this._paymentsRepo.Update(payment);
                await this._paymentsRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(payment);
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