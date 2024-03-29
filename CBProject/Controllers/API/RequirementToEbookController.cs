﻿using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class RequirementToEbookController : ApiController, IDisposable
    {
        private readonly RequirementsToEbooksRepository _requirementsToEbooksRepository;

        public RequirementToEbookController(IUnitOfWork unitOfWork)
        {
            this._requirementsToEbooksRepository = unitOfWork.RequirementsToEbooks;
        }

        // GET api/RequirementToEbook
        public async Task<IHttpActionResult> Get()
        {
            var obj = await this._requirementsToEbooksRepository
                                    .GetAllEmptyAsync();
            return Ok(obj);
        }

        // GET api/RequirementToEbook/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var obj = await this._requirementsToEbooksRepository
                                            .GetEmptyAsync(id);
            if (obj == null)
                return NotFound();
            return Ok(obj);
        }

        // POST api/RequirementToEbook
        public async Task<IHttpActionResult> Post([FromBody] RequirementToEbook obj)
        {
            if (obj == null)
                return NotFound();
            this._requirementsToEbooksRepository.Add(obj);
            await this._requirementsToEbooksRepository.SaveAsync();
            return Ok(obj);
        }

        // PUT api/RequirementToEbook/5
        public async Task<IHttpActionResult> Put([FromBody] RequirementToEbook obj)
        {
            if (obj == null)
                return NotFound();
            this._requirementsToEbooksRepository.Update(obj);
            await this._requirementsToEbooksRepository.SaveAsync();
            return Ok(obj);
        }

        // DELETE api/RequirementToEbook/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._requirementsToEbooksRepository.DeleteAsync(id);
            await this._requirementsToEbooksRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        [Route("api/RequirementToEbook/Pages")]
        public async Task<IHttpActionResult> PagesCount()
        {
            var query = this._requirementsToEbooksRepository.GetAllQueryable();
            int pages = await Pagination.CountPagesAsync(query, StaticImfo.PageSize);
            return Ok(pages);
        }

        [HttpGet]
        [Route("api/RequirementToEbook/Page/{number}")]
        public async Task<IHttpActionResult> GetPage(int number)
        {
            if (number > StaticImfo.PageSize)
                return BadRequest();
            var query = this._requirementsToEbooksRepository.GetAllQueryable();
            var myPage = Pagination.Page(query.OrderBy(c => c.ID), number, StaticImfo.PageSize);
            return Ok(myPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._requirementsToEbooksRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}