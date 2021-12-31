using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class SubscriptionPackageController : ApiController, IDisposable
    {
        private readonly SubscriptionPackageRepository _packageRepository;

        public SubscriptionPackageController(IUnitOfWork unitOfWork)
        {
            this._packageRepository = unitOfWork.SubscriptionPackages;
        }

        // GET api/SubscriptionPackage
        public async Task<IHttpActionResult> Get()
        {
            var packages = await this._packageRepository.GetAllEmptyAsync();
            return Ok(packages);
        }

        // GET api/SubscriptionPackage/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var package = await this._packageRepository.GetEmptyAsync(id);
            if (package == null)
                return NotFound();
            return Ok(package);
        }

        // POST api/SubscriptionPackage
        public async Task<IHttpActionResult> Post([FromBody] SubscriptionPackage package)
        {
            if (package == null)
                return NotFound();
            this._packageRepository.Add(package);
            await this._packageRepository.SaveAsync();
            return Ok(package);
        }

        // PUT api/SubscriptionPackage
        public async Task<IHttpActionResult> Put([FromBody] SubscriptionPackage package)
        {
            if (package == null)
                return NotFound();
            this._packageRepository.Update(package);
            await this._packageRepository.SaveAsync();
            return Ok(package);
        }

        // DELETE api/SubscriptionPackage/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._packageRepository.DeleteAsync(id);
            await this._packageRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._packageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}