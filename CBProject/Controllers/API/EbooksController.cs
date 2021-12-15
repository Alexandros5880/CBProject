using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class EbooksController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public EbooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<IEnumerable<Ebook>> GetEbooks()
        {

            var ebooks = await _unitOfWork.Ebooks.GetAllAsync();
            return ebooks;
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetEbook(int? id)
        {
            var ebook = await _unitOfWork.Ebooks.GetAsync(id);

            if (ebook == null)
                return NotFound();

            return Ok(Mapper.Map<Ebook, EbookViewModel>(ebook));

        }
        [HttpPost]
        public async Task<IHttpActionResult> CreateEbook(EbookViewModel ebookViewModel)
        {
          
            if (!ModelState.IsValid)
                return BadRequest();
            var ebook = Mapper.Map<EbookViewModel, Ebook>(ebookViewModel);
             _unitOfWork.Ebooks.Add(ebook);
            await _unitOfWork.Ebooks.SaveAsync();
            return Ok(ebook);
        }
        [HttpPut]
        public async Task<IHttpActionResult> Update(int id,EbookViewModel ebookViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var ebookInDb = await _unitOfWork.Ebooks.GetAsync(id);
            if (ebookInDb == null)
                return NotFound();
            Mapper.Map(ebookViewModel, ebookInDb);
            await _unitOfWork.Ebooks.SaveAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteEbook(int id)
        {
            var ebookInDb = await _unitOfWork.Ebooks.GetAsync(id);
            if (ebookInDb == null)
                return NotFound();

            _unitOfWork.Ebooks.Delete(id);
            _unitOfWork.Ebooks.Save();
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _unitOfWork.Ebooks.Dispose();
            base.Dispose(disposing);
        }
    }
}


