using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Messenger.Repositories;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Areas.Messenger.Controllers.API
{
    public class MessageController : ApiController, IDisposable
    {
        private readonly MesMessagesRepository _mesMessagesRepository;

        public MessageController(IUnitOfWork unitOfWork)
        {
            this._mesMessagesRepository = unitOfWork.MessengerMessages;
        }

        // GET api/Message
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._mesMessagesRepository.GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/Message/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._mesMessagesRepository.GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/Message
        public async Task<IHttpActionResult> Post([FromBody] MessengerMessage obj)
        {
            if (obj == null)
                return NotFound();
            this._mesMessagesRepository.Add(obj);
            await this._mesMessagesRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/Message/5
        public async Task<IHttpActionResult> Put([FromBody] MessengerMessage obj)
        {
            if (obj == null)
                return NotFound();
            this._mesMessagesRepository.Update(obj);
            await this._mesMessagesRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/Message/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._mesMessagesRepository.DeleteAsync(id);
            await this._mesMessagesRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._mesMessagesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}