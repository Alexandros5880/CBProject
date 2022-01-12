using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class EmployeeRequestController : ApiController, IDisposable
    {
        private readonly EmployeesRequestsRepository _employeesRequestsRepository;

        public EmployeeRequestController(IUnitOfWork unitOfWork)
        {
            this._employeesRequestsRepository = unitOfWork.EmployeesRequests;
        }

        // GET api/EmployeeRequest
        public async Task<IHttpActionResult> Get()
        {
            var records = await this._employeesRequestsRepository.GetAllEmptyAsync();
            return Ok(records);
        }

        // GET api/EmployeeRequest/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return BadRequest();
            var record = this._employeesRequestsRepository.GetEmptyAsync(id);
            return Ok(record);
        }

        // POST api/EmployeeRequest
        public async Task<IHttpActionResult> Post([FromBody] RegisterViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest();
            var request = Mapper.Map<RegisterViewModel, EmployeeRequest>(viewModel);
            this._employeesRequestsRepository.Add(request);
            await this._employeesRequestsRepository.SaveAsync();
            return Ok(request);
        }

        // PUT api/EmployeeRequest
        public async Task<IHttpActionResult> Put([FromBody] RegisterViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest();
            var request = Mapper.Map<RegisterViewModel, EmployeeRequest>(viewModel);
            this._employeesRequestsRepository.Update(request);
            await this._employeesRequestsRepository.SaveAsync();
            return Ok(request);
        }

        // DELETE api/EmployeeRequest/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            await this._employeesRequestsRepository.DeleteAsync(id);
            await this._employeesRequestsRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._employeesRequestsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}