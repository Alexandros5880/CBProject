using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Areas.Forum.Controllers.API
{
    public class SabjectController : ApiController, IDisposable
    {
        private readonly ForumSabjectRepository _sabjectRepository;

        public SabjectController(IUnitOfWork unitOfWork)
        {
            this._sabjectRepository = unitOfWork.ForumSabjectRepository;
        }

        // GET api/Sabject
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._sabjectRepository.GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/Sabject/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._sabjectRepository.GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/Sabject
        public async Task<IHttpActionResult> Post([FromBody] ForumSabject obj)
        {
            if (obj == null)
                return NotFound();
            this._sabjectRepository.Add(obj);
            await this._sabjectRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/Sabject/5
        public async Task<IHttpActionResult> Put([FromBody] ForumSabject obj)
        {
            if (obj == null)
                return NotFound();
            this._sabjectRepository.Update(obj);
            await this._sabjectRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/Sabject/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._sabjectRepository.DeleteAsync(id);
            await this._sabjectRepository.SaveAsync();
            return Ok(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._sabjectRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}