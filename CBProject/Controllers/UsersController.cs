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
        public async Task<ActionResult> Deleted()
        {
            var users = await _usersRepo.GetAllAsync();
            List<ApplicationUser> deactiveUsers = users.Where(u => u.IsInactive == true).ToList();
            return View(deactiveUsers);
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
        public async Task<ActionResult> Create(RegisterViewModel model, HttpPostedFileBase CVFile, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (model == null)
                    return HttpNotFound();
                var user = Mapper.Map<RegisterViewModel, ApplicationUser>(model);
                user.UserName = user.Email;
                await _usersRepo.AddAsync(user);
                // Save Image File
                if (ImageFile != null)
                {
                    model.ImageFile = ImageFile;
                    string FileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string FileExtension = Path.GetExtension(model.ImageFile.FileName);
                    FileName = FileName.Trim() + FileExtension;
                    model.ImagePath = StaticImfo.UsersImagesPath + user.Id + FileName;
                    model.ImageFile.SaveAs(Server.MapPath(model.ImagePath));
                }
                // Save CV File
                if (CVFile != null)
                {
                    model.CVFile = CVFile;
                    string FileName = Path.GetFileNameWithoutExtension(model.CVFile.FileName);
                    string FileExtension = Path.GetExtension(model.CVFile.FileName);
                    FileName = FileName.Trim() + FileExtension;
                    model.CVPath = StaticImfo.CVPath + user.Id + FileName;
                    model.CVFile.SaveAs(Server.MapPath(model.CVPath));
                }
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
        public async Task<ActionResult> Edit(ApplicationUserViewModel model, HttpPostedFileBase CVFile, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (model == null)
                    return HttpNotFound();
                // Save Image File
                var imgPath = false;
                if (ImageFile != null)
                {
                    model.ImageFile = ImageFile;
                    string FileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string FileExtension = Path.GetExtension(model.ImageFile.FileName);
                    FileName = FileName.Trim() + FileExtension;
                    model.ImagePath = StaticImfo.UsersImagesPath + model.Id + FileName;
                    model.ImageFile.SaveAs(Server.MapPath(model.ImagePath));
                    imgPath = true;
                }
                // Save CV File
                var cvPath = false;
                if (CVFile != null)
                {
                    model.CVFile = CVFile;
                    string FileName = Path.GetFileNameWithoutExtension(model.CVFile.FileName);
                    string FileExtension = Path.GetExtension(model.CVFile.FileName);
                    FileName = FileName.Trim() + FileExtension;
                    model.CVPath = StaticImfo.CVPath + model.Id + FileName;
                    model.CVFile.SaveAs(Server.MapPath(model.CVPath));
                    cvPath = true;
                }
                var userDB = await _usersRepo.GetAsync(model.Id);
                var imgOldPath = (await this._usersRepo.GetAsync(model.Id)).ImagePath;
                var cvOldPath = (await this._usersRepo.GetAsync(model.Id)).CVPath;
                var user = Mapper.Map<ApplicationUserViewModel, ApplicationUser>(model);
                if (!imgPath) user.ImagePath = imgOldPath;
                else
                {
                    FileInfo img = new FileInfo(HttpRuntime.AppDomainAppPath + imgOldPath);
                    if (img.Exists)
                    {
                        img.Delete();
                    }
                }
                if (!cvPath) user.CVPath = cvOldPath;
                else
                {
                    FileInfo file = new FileInfo(HttpRuntime.AppDomainAppPath + cvOldPath);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                user.UserName = user.Email;
                if (model.Password == null || model.Password.Length == 0)
                {
                    user.Password = userDB.Password;
                } 
                else
                {
                    if (model.Password == model.ConfirmPassword)
                    {
                        _usersRepo.ChangePassword(user.Id, user.Password);
                    }
                }
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                var user = await _usersRepo.GetAsync(model.Id);
                if (user == null)
                    return HttpNotFound();
                var viewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
                viewModel.OtherRoles = await _usersRepo.GetRolesForUserAsync(user);
                ICollection<string> roles = await _usersRepo.GetRolesAsync(user);
                viewModel.MyRoles = await _rolesRepo.GetAllByNamesAsync(roles);
                return View(viewModel);
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
        public async Task<ActionResult> DeleteForEver(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = await _usersRepo.GetAsync(id);
            if (user == null)
                return HttpNotFound();
            FileInfo img = new FileInfo(HttpRuntime.AppDomainAppPath + user.ImagePath);
            if (img.Exists)
            {
                img.Delete();
            }
            FileInfo file = new FileInfo(HttpRuntime.AppDomainAppPath + user.CVPath);
            if (file.Exists)
            {
                file.Delete();
            }
            await this._usersRepo.DeleteRealAsync(user.Id);
            var users = await _usersRepo.GetAllAsync();
            List<ApplicationUser> activeUsers = users.Where(u => u.IsInactive == false).ToList();
            return View("Index", activeUsers);
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
        public async Task<ActionResult> Activate(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var user = await _usersRepo.GetAsync(id);
            if (user == null)
                return HttpNotFound();
            user.IsInactive = false;
            await _usersRepo.UpdateAsync(user);
            var users = await _usersRepo.GetAllAsync();
            List<ApplicationUser> activeUsers = users.Where(u => u.IsInactive == false).ToList();
            return View("Index", activeUsers);
        }
    }
}
