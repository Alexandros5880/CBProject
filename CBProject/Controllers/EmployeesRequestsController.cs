using CBProject.HelperClasses.Interfaces;
using CBProject.Repositories;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    [Authorize]
    public class EmployeesRequestsController : Controller
    {
        private readonly EmployeesRequestsRepository _employeesRequestsRepository;
        public EmployeesRequestsController(IUnitOfWork unitOfWork)
        {
            this._employeesRequestsRepository = unitOfWork.EmployeesRequests;
        }
        public async Task<ActionResult> Index()
        {
            var requests = await this._employeesRequestsRepository.GetAllAsync();
            return View(requests);
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var request = await this._employeesRequestsRepository.GetAsync(id);
            return View(request);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var request = await this._employeesRequestsRepository.GetAsync(id);
            return View(request);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await this._employeesRequestsRepository.DeleteAsync(id);
            return RedirectToAction("Index");
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