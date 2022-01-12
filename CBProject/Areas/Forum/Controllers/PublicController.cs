using CBProject.Areas.Forum.Repositories;
using CBProject.HelperClasses.Interfaces;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Areas.Forum.Controllers
{
    public class PublicController : Controller, IDisposable
    {
        private readonly ForumMessagesRepository _forumeMessagesRepository;
        private readonly UsersRepo _usersRepo;
        private readonly RolesRepo _rolesRepo;

        public PublicController(IUnitOfWork unitOfWork, IUsersRepo usersRepo, IRolesRepo rolesRepo)
        {
            this._forumeMessagesRepository = unitOfWork.ForumMessages;
            this._usersRepo = (UsersRepo)usersRepo;
            this._rolesRepo = (RolesRepo)rolesRepo;
        }

        // GET: Forum/Public
        public async Task<ActionResult> Index()
        {
            var messages = await this._forumeMessagesRepository.GetAllAsync();
            return View(messages);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._forumeMessagesRepository.Dispose();
                this._usersRepo.Dispose();
                this._rolesRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}