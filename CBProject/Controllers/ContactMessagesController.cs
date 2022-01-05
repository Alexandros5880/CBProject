using CBProject.HelperClasses.Interfaces;
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