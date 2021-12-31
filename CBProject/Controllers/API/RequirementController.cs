using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class RequirementController : ApiController, IDisposable
    {
        private readonly RequirementsRepository _requirementsRepository;

        public RequirementController(IUnitOfWork unitOfWork)
        {
            this._requirementsRepository = unitOfWork.Requirements;
        }

        // GET api/Requirement
        public async Task<IHttpActionResult> Get()
        {
            var requirements = await this._requirementsRepository.GetAllEmptyAsync();
            return Ok(requirements);
        }

        // GET api/Requirement/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var requirement = await this._requirementsRepository.GetEmptyAsync(id);
            if (requirement == null)
                return NotFound();
            return Ok(requirement);
        }

        // POST api/Requirement
        public async Task<IHttpActionResult> Post([FromBody] Requirement requirement)
        {
            if (requirement == null)
                return NotFound();
            this._requirementsRepository.Add(requirement);
            await this._requirementsRepository.SaveAsync();
            return Ok(requirement);
        }

        // PUT api/Requirement/5
        public async Task<IHttpActionResult> Put([FromBody] Requirement requirement)
        {
            if (requirement == null)
                return NotFound();
            this._requirementsRepository.Update(requirement);
            await this._requirementsRepository.SaveAsync();
            return Ok(requirement);
        }

        // DELETE api/Requirement/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._requirementsRepository.DeleteAsync(id);
            await this._requirementsRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._requirementsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}