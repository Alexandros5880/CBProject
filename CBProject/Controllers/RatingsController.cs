﻿using System;
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
    public class RatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ratings
        public async Task<ActionResult> Index()
        {
            var ratings = db.Ratings.Include(r => r.Rater).Include(r => r.Video);
            return View(await ratings.ToListAsync());
        }

        // GET: Ratings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // GET: Ratings/Create
        public ActionResult Create()
        {
            ViewBag.RaterId = new SelectList(db.ApplicationUsers, "Id", "FirstName");
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title");
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Rate,RaterId,VideoId")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Ratings.Add(rating);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RaterId = new SelectList(db.ApplicationUsers, "Id", "FirstName", rating.RaterId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", rating.VideoId);
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            ViewBag.RaterId = new SelectList(db.ApplicationUsers, "Id", "FirstName", rating.RaterId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", rating.VideoId);
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Rate,RaterId,VideoId")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rating).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RaterId = new SelectList(db.ApplicationUsers, "Id", "FirstName", rating.RaterId);
            ViewBag.VideoId = new SelectList(db.Videos, "Id", "Title", rating.VideoId);
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rating rating = await db.Ratings.FindAsync(id);
            if (rating == null)
            {
                return HttpNotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rating rating = await db.Ratings.FindAsync(id);
            db.Ratings.Remove(rating);
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
