using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    [Authorize]
    public class ContactMessagesController : Controller, IDisposable
    {
        private readonly MessagesRepository _messageRepository;
        public ContactMessagesController(IUnitOfWork unitOfWork)
        {
            this._messageRepository = unitOfWork.Messages;
        }
        public async Task<ActionResult> Index()
        {
            var messages = await this._messageRepository.GetAllAsync();
            return View(messages);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var message = await this._messageRepository.GetAsync(id);
            return View(message);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactMessage message)
        {
            if (message == null)
            {
                return HttpNotFound();
            }
            this._messageRepository.Add(message);
            await this._messageRepository.SaveAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var message = await this._messageRepository.GetAsync(id);
            if (message == null)
                return HttpNotFound();
            return View(message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContactMessage message)
        {
            if (message == null)
                return HttpNotFound();
            this._messageRepository.Update(message);
            await this._messageRepository.SaveAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var message = await this._messageRepository.GetAsync(id);
            if (message == null)
                return HttpNotFound();
            return View(message);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ContactMessage message)
        {
            try
            {
                if (message == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                await this._messageRepository.DeleteAsync(message.ID);
                await this._messageRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._messageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}