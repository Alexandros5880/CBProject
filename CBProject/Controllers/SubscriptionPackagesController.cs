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

namespace CBProject.Controllers
{
    public class SubscriptionPackagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubscriptionPackages
        public async Task<ActionResult> Index()
        {
            return View(await db.SubcriptionPackages.ToListAsync());
        }

        // GET: SubscriptionPackages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionPackage subscriptionPackage = await db.SubcriptionPackages.FindAsync(id);
            if (subscriptionPackage == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionPackage);
        }

        // GET: SubscriptionPackages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Price,Duration,AutoSubscription,StartDate")] SubscriptionPackage subscriptionPackage)
        {
            if (ModelState.IsValid)
            {
                db.SubcriptionPackages.Add(subscriptionPackage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(subscriptionPackage);
        }

        // GET: SubscriptionPackages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionPackage subscriptionPackage = await db.SubcriptionPackages.FindAsync(id);
            if (subscriptionPackage == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionPackage);
        }

        // POST: SubscriptionPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Price,Duration,AutoSubscription,StartDate")] SubscriptionPackage subscriptionPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriptionPackage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(subscriptionPackage);
        }

        // GET: SubscriptionPackages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriptionPackage subscriptionPackage = await db.SubcriptionPackages.FindAsync(id);
            if (subscriptionPackage == null)
            {
                return HttpNotFound();
            }
            return View(subscriptionPackage);
        }

        // POST: SubscriptionPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubscriptionPackage subscriptionPackage = await db.SubcriptionPackages.FindAsync(id);
            db.SubcriptionPackages.Remove(subscriptionPackage);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
