using AutoMapper;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RolesRepo _rolesRepo;
        private readonly UsersRepo _userRepo;
        private ApplicationDbContext _context { get; set; }
        public RolesController(IApplicationDbContext context, IRolesRepo rolesRepo, IUsersRepo usersRepo)
        {
            this._context = (ApplicationDbContext)context;
            this._rolesRepo = (RolesRepo) rolesRepo;
            this._userRepo = (UsersRepo) usersRepo;
        }
        public async Task<ActionResult> Index()
        {
            ICollection<ApplicationRole> roles = await this._rolesRepo.GetAllAsync();
            //ICollection<ApplicationRoleViewModel> viewModels = 
            //    Mapper.Map<ICollection<ApplicationRole>, ICollection<ApplicationRoleViewModel>>(roles);
            return View(roles);
        }
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var role = await _rolesRepo.GetAsync(id);
            if (role == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<ApplicationRole, IdentityRoleViewModel>(role);
            return View(viewModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IdentityRoleViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return HttpNotFound();
                }
                ApplicationRole role = new ApplicationRole()
                {
                    Name = model.Name,
                    Level = model.Level
                };
                await _rolesRepo.AddAsync(role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var role = await _rolesRepo.GetAsync(id);
            if (role == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<ApplicationRole, IdentityRoleViewModel>(role);
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IdentityRoleViewModel model)
        {
            ApplicationRole role = await _rolesRepo.GetAsync(model.Id);
            role.Level = model.Level;
            if (role == null)
                return HttpNotFound();
            role.Name = model.Name;
            await _rolesRepo.UpdateAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var role = await _rolesRepo.GetAsync(id);
            if (role == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<ApplicationRole, IdentityRoleViewModel>(role);
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(IdentityRoleViewModel model)
        {
            try
            {
                if (model.Id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var role = await _rolesRepo.GetAsync(model.Id);
                if (role == null)
                    return HttpNotFound();
                await _rolesRepo.DeleteAsync(role.Name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}