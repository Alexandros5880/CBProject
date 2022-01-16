using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Areas.Forum.Controllers.API
{
    public class QuestionController : ApiController, IDisposable
    {
        private readonly ForumQuestionRepository _questionRepository;
        
        public QuestionController(IUnitOfWork unitOfWork)
        {
            this._questionRepository = unitOfWork.ForumQuestionRepository;
        }

        // GET api/Question
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._questionRepository.GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/Question/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._questionRepository.GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/Question
        public async Task<IHttpActionResult> Post([FromBody] ForumQuestion obj)
        {
            if (obj == null)
                return NotFound();
            this._questionRepository.Add(obj);
            await this._questionRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/Question/5
        public async Task<IHttpActionResult> Put([FromBody] ForumQuestion obj)
        {
            if (obj == null)
                return NotFound();
            this._questionRepository.Update(obj);
            await this._questionRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/Question/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._questionRepository.DeleteAsync(id);
            await this._questionRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._questionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}