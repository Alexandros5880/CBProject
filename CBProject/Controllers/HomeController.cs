using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly EbooksRepository _ebooksRepository;
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;
        private readonly CategoriesRepository _categoriesRepo;
        private readonly VideosRepository _videosRepository;
        private readonly RequirementsRepository _requirementsRepository;
        private readonly MessagesRepository _messagesRepository;
        public HomeController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._categoriesRepo = unitOfWork.Categories;
            this._videosRepository = unitOfWork.Videos;
            this._usersRepo = (UsersRepo)usersRepo;
            this._rolesRepo = (RolesRepo)rolesRepo;
            this._requirementsRepository = unitOfWork.Requirements;
            this._messagesRepository = unitOfWork.Messages;
        }
        public async Task<ActionResult> Index()
        {
            var ebooks = await this._ebooksRepository.GetAllAsync();
            var videos = await this._videosRepository.GetAllAsync();
            var viewModel = new HomeViewModel();
            viewModel.Ebooks = new List<EbookViewModel>();
            viewModel.Videos = new List<VideoViewModel>();
            foreach (var ebook in ebooks)
            {
                viewModel.Ebooks.Add(Mapper.Map<Ebook, EbookViewModel>(ebook));
            }
            foreach (var video in videos)
            {
                viewModel.Videos.Add(Mapper.Map<Video, VideoViewModel>(video));
            }
            return View(viewModel);
        }
        public async Task<ActionResult> About()
        {
            return View();
        }
        public async Task<ActionResult> Contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUser user = await this._usersRepo.GetAsync(User.Identity.GetUserId());
                ContactViewModel contact = new ContactViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.PhoneNumber,
                    Email = user.Email
                };
                return View(contact);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactViewModel contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            HelperClasses.EmailService email = new HelperClasses.EmailService();
            await email.SendEmailContact(contact);
            // Find Sender If Exists
            var user = await this._usersRepo.GetByEmailAsync(contact.Email);
            // Create Message
            ContactMessage message = new ContactMessage()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Phone = contact.Phone,
                Subject = contact.Subject,
                Message = contact.Message,
                UploatedDate = DateTime.Today
            };
            this._messagesRepository.Add(message);
            await this._messagesRepository.SaveAsync();
            return View();
        }
        public async Task<ActionResult> Lessons()
        {
            return View();
        }
        public async Task<ActionResult> Terms()
        {
            return View();
        }
        public async Task<ActionResult> Dashboard()
        {
            var userId = User.Identity.GetUserId();
            var user = await this._usersRepo.GetAsync(userId);
            RoleLevel access = RoleLevel.SUPERLOW;
            foreach (var role in user.Roles)
            {
                var myRole = await this._rolesRepo.GetAsync(role.RoleId);
                if (myRole.Level == RoleLevel.FULL)
                {
                    access = myRole.Level;
                }
                else if (myRole.Level == RoleLevel.PLUSSFULL)
                {
                    if (access != RoleLevel.FULL)
                    {
                        access = myRole.Level;
                    }
                }
                else if (myRole.Level == RoleLevel.MIDDLE)
                {
                    if (access != RoleLevel.FULL &&
                        access != RoleLevel.PLUSSFULL)
                    {
                        access = myRole.Level;
                    }
                }
                else if (myRole.Level == RoleLevel.LOW)
                {
                    if (access != RoleLevel.FULL &&
                        access != RoleLevel.PLUSSFULL &&
                        access != RoleLevel.MIDDLE)
                    {
                        access = myRole.Level;
                    }
                }
                else if (myRole.Level == RoleLevel.SUPERLOW)
                {
                    if (access != RoleLevel.FULL &&
                        access != RoleLevel.PLUSSFULL &&
                        access != RoleLevel.MIDDLE &&
                        access != RoleLevel.LOW)
                    {
                        access = myRole.Level;
                    }
                }
            }
            switch (access)
            {
                case RoleLevel.SUPERLOW:
                    return RedirectToAction("Index", "Home");
                case RoleLevel.LOW:
                    return RedirectToAction("Index", "Ebooks");
                case RoleLevel.MIDDLE:
                    return RedirectToAction("Index", "Ebooks");
                case RoleLevel.PLUSSFULL:
                    return RedirectToAction("Index", "Roles");
                case RoleLevel.FULL:
                    return RedirectToAction("Index", "Users");
                default:
                    return RedirectToAction("Index", "Home");
            }
        }
        public async Task<ActionResult> EmployeeRegistration()
        {
            var roles = await this._rolesRepo.GetAllQuerable().Where(r => !r.Name.Equals("Admin") 
                                                                            && !r.Name.Equals("Guest") 
                                                                            && !r.Name.Equals("Student"))
                                                                .ToListAsync();
            RegisterViewModel viewModel = new RegisterViewModel()
            {
                Roles = new SelectList(roles, "Id", "Name")
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EmplyeeRegistration(RegisterViewModel viewModel)
        {
            return View("Index");
        }

        public async Task<ActionResult> _Read(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ebook ebook = await this._ebooksRepository.GetAsync(id);
            if (ebook == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Ebook, EbookViewModel>(ebook);
            return PartialView("_Read", viewModel);
        }
        public async Task<ActionResult> _Watch(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = await this._videosRepository.GetAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Video, VideoViewModel>(video);
            return PartialView("_Watch", viewModel);
        }

    }
}