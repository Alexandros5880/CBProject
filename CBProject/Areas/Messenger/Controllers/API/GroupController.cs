using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Messenger.Repositories;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Areas.Messenger.Controllers.API
{
    public class GroupController : ApiController, IDisposable
    {
        private readonly MesGroupsRepository _mesGroupsRepository;

        public GroupController(IUnitOfWork unitoOfWork)
        {
            this._mesGroupsRepository = unitoOfWork.MessengerGroups;
        }

        // GET api/Group
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._mesGroupsRepository.GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/Group/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._mesGroupsRepository.GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/Group
        public async Task<IHttpActionResult> Post([FromBody] MessengerGroup obj)
        {
            if (obj == null)
                return NotFound();
            this._mesGroupsRepository.Add(obj);
            await this._mesGroupsRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/Group/5
        public async Task<IHttpActionResult> Put([FromBody] MessengerGroup obj)
        {
            if (obj == null)
                return NotFound();
            this._mesGroupsRepository.Update(obj);
            await this._mesGroupsRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/Group/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._mesGroupsRepository.DeleteAsync(id);
            await this._mesGroupsRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._mesGroupsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}