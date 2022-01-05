using AutoMapper;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Controllers
{
    public class HomeController : Controller
    {
        private EbooksRepository _ebooksRepository;
        private UsersRepo _usersRepo;
        private CategoriesRepository _categoriesRepo;
        private VideosRepository _videosRepository;
        private readonly RequirementsRepository _requirementsRepository;
        private readonly MessagesRepository _messagesRepository;
        public HomeController(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._ebooksRepository = unitOfWork.Ebooks;
            this._categoriesRepo = unitOfWork.Categories;
            this._videosRepository = unitOfWork.Videos;
            this._usersRepo = (UsersRepo)usersRepo;
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
            ContactMessage message;
            if (user == null)
            {
                message = new ContactMessage()
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Subject = contact.Subject,
                    Message = contact.Message
                };
            }
            else
            {
                message = new ContactMessage()
                {
                    User = user,
                    Subject = contact.Subject,
                    Message = contact.Message
                };
            }
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
    }
}