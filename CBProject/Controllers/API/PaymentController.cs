using CBProject.HelperClasses.Interfaces;
using CBProject.Models.EntityModels;
using CBProject.Repositories.IdentityRepos;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CBProject.Controllers.API
{
    public class PaymentController : ApiController, IDisposable
    {
        private readonly PaymentsRepository _paymentsRepository;

        public PaymentController(IUnitOfWork unitOfWork)
        {
            this._paymentsRepository = unitOfWork.Payments;
        }

        // GET api/Payment
        public async Task<IHttpActionResult> Get()
        {
            var payments = await this._paymentsRepository.GetAllAsync();
            return Ok(payments);
        }

        // GET api/Payment/5
        public async Task<IHttpActionResult> Get(int? id)
        {
            if (id == null)
                return NotFound();
            var payment = await this._paymentsRepository.GetAsync(id);
            return Ok(payment);
        }

        // POST api/Payment
        public async Task<IHttpActionResult> Post([FromBody] Payment payment)
        {
            if (payment == null)
                return NotFound();
            this._paymentsRepository.Add(payment);
            await this._paymentsRepository.SaveAsync();
            return Ok(payment);
        }

        // PUT api/Payment/5
        public async Task<IHttpActionResult> Put([FromBody] Payment payment)
        {
            if (payment == null)
                return NotFound();
            this._paymentsRepository.Update(payment);
            await this._paymentsRepository.SaveAsync();
            return Ok(payment);
        }

        // DELETE api/Payment/5
        public async Task<IHttpActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            await this._paymentsRepository.DeleteAsync(id);
            await this._paymentsRepository.SaveAsync();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._paymentsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}