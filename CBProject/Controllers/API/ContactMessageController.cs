using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class ContactMessageController : ApiController, IDisposable
    {
        private readonly MessagesRepository _messagesRepository;

        public ContactMessageController(IUnitOfWork unitOfWork)
        {
            this._messagesRepository = unitOfWork.Messages;
        }

        // GET api/ContactMessage
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._messagesRepository.GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/ContactMessage/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return BadRequest();
            var obj = await this._messagesRepository.GetEmptyAsync(id);
            if (obj == null)
                return BadRequest();
            return Ok(obj);
        }

        // POST api/ContactMessage
        public async Task<IHttpActionResult> Post(ContactMessage obj)
        {
            if (obj == null)
                return BadRequest();
            this._messagesRepository.Add(obj);
            await this._messagesRepository.SaveAsync();
            return Ok();
        }

        // PUT api/ContactMessage/5
        public async Task<IHttpActionResult> Put(ContactMessage obj)
        {
            if (obj == null)
                return BadRequest();
            this._messagesRepository.Update(obj);
            this._messagesRepository.Update(obj);
            await this._messagesRepository.SaveAsync();
            return Ok();
        }

        // DELETE api/ContactMessage/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            await this._messagesRepository.DeleteAsync(id);
            await this._messagesRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._messagesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}