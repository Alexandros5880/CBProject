using CBProject.Areas.Forum.Repositories;
using CBProject.HelperClasses.Interfaces;
using Microsoft.AspNet.SignalR;
using CBProject.Repositories.IdentityRepos.Interfaces;
using CBProject.Repositories.IdentityRepos;
using CBProject.Models.EntityModels;
using System.Web;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CBProject.Areas.Forum
{

    public class ForumHub : Hub
    {

        private readonly ForumSabjectRepository _forumSabjectRepository;
        private readonly ForumQuestionRepository _forumQuestionRepository;
        private readonly ForumAnswerRepository _forumAnswerRepository;
        private readonly UsersRepo _usersRepo;
        ApplicationUser user;

        public ForumHub(IUnitOfWork unitOfWork, IUsersRepo usersRepo)
        {
            this._forumSabjectRepository = unitOfWork.ForumSabject;
            this._forumQuestionRepository = unitOfWork.ForumQuestion;
            this._forumAnswerRepository = unitOfWork.ForumAnswer;
            this._usersRepo = (UsersRepo)usersRepo;
        }

        // Example
        public async Task<dynamic> SendMessage(string userName, string message)
        {
            this.user = await this._usersRepo.GetByEmailAsync(userName);
            return await Clients.All.sendMessage(userName, message);
        }

    }
}