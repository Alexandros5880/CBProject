using CBProject.Areas.Forum.Repositories;
using CBProject.HelperClasses.Interfaces;
using Microsoft.AspNet.SignalR;

namespace CBProject.Areas.Forum
{

    public class ForumHub : Hub
    {

        private readonly ForumSabjectRepository _forumSabjectRepository;
        private readonly ForumQuestionRepository _forumQuestionRepository;
        private readonly ForumAnswerRepository _forumAnswerRepository;

        public ForumHub(IUnitOfWork unitOfWork)
        {
            this._forumSabjectRepository = unitOfWork.ForumSabject;
            this._forumQuestionRepository = unitOfWork.ForumQuestion;
            this._forumAnswerRepository = unitOfWork.ForumAnswer;
        }

        // Create Delete Subject
        [Authorize]
        public void CreateSubject()
        {

        }
        [Authorize]
        public void DeleteSubject()
        {

        }

        // Create Delete Question
        [Authorize]
        public void CreateQuestion()
        {

        }
        [Authorize]
        public void DeleteQuestion()
        {

        }

        // Create Delete Answer
        [Authorize]
        public void CreateAnswer()
        {

        }
        [Authorize]
        public void DeleteAnswer()
        {

        }




        //public void Announce(string message)
        //{
        //    Clients.All.Announce(message);
        //}

    }
}