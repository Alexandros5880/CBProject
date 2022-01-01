using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class TagToEbookController : ApiController, IDisposable
    {
        private readonly TagsToEbooksRepository _tagsToEbooksRepository;

        public TagToEbookController(IUnitOfWork unitOfWork)
        {
            this._tagsToEbooksRepository = unitOfWork.TagsToEbooks;
        }

        // GET api/TagToEbook
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._tagsToEbooksRepository
                                            .GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/TagToEbook/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._tagsToEbooksRepository
                                                .GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/TagToEbook
        public async Task<IHttpActionResult> Post([FromBody] TagToEbook obj)
        {
            if (obj == null)
                return NotFound();
            this._tagsToEbooksRepository.Add(obj);
            await this._tagsToEbooksRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/TagToEbook/5
        public async Task<IHttpActionResult> Put([FromBody] TagToEbook obj)
        {
            if (obj == null)
                return NotFound();
            this._tagsToEbooksRepository.Update(obj);
            await this._tagsToEbooksRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/TagToEbook/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._tagsToEbooksRepository.DeleteAsync(id);
            await this._tagsToEbooksRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._tagsToEbooksRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}