using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Areas.Forum.Controllers.API
{
    public class AnswerController : ApiController, IDisposable
    {
        private ForumAnswerRepository _answersRepository;

        public AnswerController(IUnitOfWork unitOfWork)
        {
            this._answersRepository = unitOfWork.ForumAnswerRepository;
        }

        // GET api/Answer
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._answersRepository.GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/Answer/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._answersRepository.GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/Answer
        public async Task<IHttpActionResult> Post([FromBody] ForumAnswer obj)
        {
            if (obj == null)
                return NotFound();
            this._answersRepository.Add(obj);
            await this._answersRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/Answer
        public async Task<IHttpActionResult> Put([FromBody] ForumAnswer obj)
        {
            if (obj == null)
                return NotFound();
            this._answersRepository.Update(obj);
            await this._answersRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/Answer/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._answersRepository.DeleteAsync(id);
            await this._answersRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._answersRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}