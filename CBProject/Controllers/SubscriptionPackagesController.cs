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

        // TODO: View Model(Related records: payments, EnumPaymentMethod)
        public ActionResult Create()
        {
            return View();
        }

        // TODO: View Model(Related records: payments, EnumPaymentMethod)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Price,Duration,AutoSubscription,StartDate")] SubscriptionPackage subscriptionPackage)
        {
            if (ModelState.IsValid)
            {
                this._subscriptionRepo.Add(subscriptionPackage);
                await this._subscriptionRepo.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(subscriptionPackage);
        }

        // TODO: View Model(Related records: payments, EnumPaymentMethod)
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
            return View(subscriptionPackage);
        }

        // TODO: View Model(Related records: payments, EnumPaymentMethod)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Price,Duration,AutoSubscription,StartDate")] SubscriptionPackage subscriptionPackage)
        {
            if (ModelState.IsValid)
            {
                this._subscriptionRepo.Update(subscriptionPackage);
                await this._subscriptionRepo.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(subscriptionPackage);
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