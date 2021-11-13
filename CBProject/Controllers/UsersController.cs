using AutoMapper;
using CBProject.HelperClasses;
using CBProject.Models;
using CBProject.Models.ViewModels;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly RolesRepo _rolesRepo;
        private readonly UsersRepo _usersRepo;
        public UsersController(IRolesRepo rolesRepo, IUsersRepo usersRepo)
        {
            this._rolesRepo = (RolesRepo)rolesRepo;
            this._usersRepo = (UsersRepo)usersRepo;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _usersRepo.GetAllAsync();
            List<ApplicationUser> activeUsers = users.Where(u => u.IsInactive == false).ToList();
            return View(activeUsers);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = await _usersRepo.GetAsync(id);
            if (user == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
            ICollection<string> roles = await _usersRepo.GetRolesAsync(user);
            viewModel.MyRoles = await _rolesRepo.GetAllByNamesAsync(roles);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model, HttpPostedFileBase CVFile)
        {
            try
            {
                if (model == null)
                    return HttpNotFound();
                // Get CV file
                if (CVFile != null)
                {
                    model.CVFile = CVFile;
                    string FileName = Path.GetFileNameWithoutExtension(model.CVFile.FileName);
                    string FileExtension = Path.GetExtension(model.CVFile.FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                    model.CVPath = Server.MapPath(StaticImfo.CVPath + model.FirstName + " " + model.LastName + FileName);
                    model.CVFile.SaveAs(model.CVPath);
                }
                var user = Mapper.Map<RegisterViewModel, ApplicationUser>(model);
                user.UserName = user.Email;
                await _usersRepo.AddAsync(user);
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
            var user = await _usersRepo.GetAsync(id);
            if (user == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
            viewModel.OtherRoles = await _usersRepo.GetRolesForUserAsync(user);
            ICollection<string> roles = await _usersRepo.GetRolesAsync(user);
            viewModel.MyRoles = await _rolesRepo.GetAllByNamesAsync(roles);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUserViewModel model, HttpPostedFileBase CVFile)
        {
            try
            {
                if (model == null)
                    return HttpNotFound();
                // Get CV file
                if (CVFile != null)
                {
                    model.CVFile = CVFile;
                    string FileName = Path.GetFileNameWithoutExtension(model.CVFile.FileName);
                    string FileExtension = Path.GetExtension(model.CVFile.FileName);
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
                    model.CVPath = Server.MapPath(StaticImfo.CVPath + model.FirstName + " " + model.LastName + FileName);
                    model.CVFile.SaveAs(model.CVPath);
                }

                var userDB = await _usersRepo.GetAsync(model.Id);
                var user = Mapper.Map<ApplicationUserViewModel, ApplicationUser>(model);
                user.UserName = user.Email;
                if (user.Password.Length == 0)
                    user.Password = userDB.Password;

                if (model.RemoveRoles != null)
                {
                    if (model.RemoveRoles.Count > 0)
                    {
                        foreach (var roleId in model.RemoveRoles)
                        {
                            IdentityRole r = _rolesRepo.Get(roleId);
                            _usersRepo.RemoveRole(user, r);
                        }
                    }
                }
                
                if (model.AddRoles != null)
                {
                    if (model.AddRoles.Count > 0)
                    {
                        foreach (var roleId in model.AddRoles)
                        {
                            IdentityRole r = _rolesRepo.Get(roleId);
                            _usersRepo.AddRole(user, r);
                        }
                    }
                }

                int result = await _usersRepo.UpdateAsync(user);
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
            var user = await _usersRepo.GetAsync(id);
            if (user == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ApplicationUserViewModel model)
        {
            try
            {
                if (model.Id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var user = await _usersRepo.GetAsync(model.Id);
                if (user == null)
                    return HttpNotFound();
                //await _usersRepo.DeleteAsync(user.Id);
                user.IsInactive = true;
                await _usersRepo.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
