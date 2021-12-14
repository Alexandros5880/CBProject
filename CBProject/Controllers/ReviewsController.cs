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

namespace CBProject.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public async Task<ActionResult> Index()
        {
            var reviews = db.Reviews.Include(r => r.Reviewer).Include(r => r.Video);
            return View(await reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.ReviewerId = new SelectList(db.ApplicationUsers, "Id", "FirstName");
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ReviewerId,Comment,VideoId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ReviewerId = new SelectList(db.ApplicationUsers, "Id", "FirstName", review.ReviewerId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", review.VideoId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReviewerId = new SelectList(db.ApplicationUsers, "Id", "FirstName", review.ReviewerId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", review.VideoId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ReviewerId,Comment,VideoId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ReviewerId = new SelectList(db.ApplicationUsers, "Id", "FirstName", review.ReviewerId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", review.VideoId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = await db.Reviews.FindAsync(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Review review = await db.Reviews.FindAsync(id);
            db.Reviews.Remove(review);
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
