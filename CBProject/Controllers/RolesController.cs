using AutoMapper;
using CBProject.Models.ViewModels;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class RolesController : Controller
    {
        private readonly RolesRepo _rolesRepo;
        private readonly UsersRepo _userRepo;
        public RolesController(IRolesRepo rolesRepo, IUsersRepo usersRepo)
        {
            this._rolesRepo = (RolesRepo) rolesRepo;
            this._userRepo = (UsersRepo) usersRepo;
        }

        public async Task<ActionResult> Index()
        {
            ICollection<IdentityRole> roles = await this._rolesRepo.GetAllAsync();
            //ICollection<IdentityRoleViewModel> viewModels = 
            //    Mapper.Map<ICollection<IdentityRole>, ICollection<IdentityRoleViewModel>>(roles);
            return View(roles);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var role = await _rolesRepo.GetAsync(id);
            if (role == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<IdentityRole, IdentityRoleViewModel>(role);
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
                await _rolesRepo.AddAsync(model.Name);
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
            var viewModel = Mapper.Map<IdentityRole, IdentityRoleViewModel>(role);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(IdentityRoleViewModel model)
        {
            try
            {
                IdentityRole role = await _rolesRepo.GetAsync(model.Id);
                if (role == null)
                    return HttpNotFound();
                role.Name = model.Name;
                await _rolesRepo.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }   
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var role = await _rolesRepo.GetAsync(id);
            if (role == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<IdentityRole, IdentityRoleViewModel>(role);
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