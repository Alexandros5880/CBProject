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
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using CBProject.HelperClasses.Interfaces;

namespace CBProject.Controllers
{
    public class ContentTypesController : Controller
    {
        private ContentTypeRepository _contentType;
        public ContentTypesController(IUnitOfWork unitOfWork)
        {
            this._contentType = unitOfWork.ContentTypes;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _contentType.GetAllAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentType contentType = await this._contentType.GetAsync(id);
            if (contentType == null)
            {
                return HttpNotFound();
            }
            return View(contentType);
        }

        public ActionResult Create()
        {
            return View();
        }

        // TODO: Create View Model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] ContentType contentType)
        {
            if (ModelState.IsValid)
            {
                this._contentType.Add(contentType);
                await this._contentType.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(contentType);
        }

        // TODO: Create View Model
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentType contentType = await this._contentType.GetAsync(id);
            if (contentType == null)
            {
                return HttpNotFound();
            }
            return View(contentType);
        }

        // TODO: Create View Model
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] ContentType contentType)
        {
            if (ModelState.IsValid)
            {
                this._contentType.Update(contentType);
                await this._contentType.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(contentType);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentType contentType = await this._contentType.GetAsync(id);
            if (contentType == null)
            {
                return HttpNotFound();
            }
            return View(contentType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            this._contentType.Delete(id);
            await this._contentType.SaveAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._contentType.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}