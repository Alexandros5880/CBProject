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
    public class VideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Videos
        public async Task<ActionResult> Index()
        {
            var videos = db.Videos.Include(v => v.Category).Include(v => v.ContentCreator);
            return View(await videos.ToListAsync());
        }

        // GET: Videos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = await db.Videos.FindAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name");
            ViewBag.CreatorId = new SelectList(db.ApplicationUsers, "Id", "FirstName");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Thumbnail,VideoPath,Description,UploadDate,CreatorId,CategoryId,Url")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", video.CategoryId);
            ViewBag.CreatorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", video.CreatorId);
            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = await db.Videos.FindAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", video.CategoryId);
            ViewBag.CreatorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", video.CreatorId);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Thumbnail,VideoPath,Description,UploadDate,CreatorId,CategoryId,Url")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "ID", "Name", video.CategoryId);
            ViewBag.CreatorId = new SelectList(db.ApplicationUsers, "Id", "FirstName", video.CreatorId);
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = await db.Videos.FindAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Video video = await db.Videos.FindAsync(id);
            db.Videos.Remove(video);
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
