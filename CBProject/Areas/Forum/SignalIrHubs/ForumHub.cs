using Microsoft.AspNet.SignalR;

namespace CBProject.Areas.Forum
{
    public class ForumHub : Hub
    {
        
        // Create Delete Subject
        public void CreateSubject()
        {

        }
        public void DeleteSubject()
        {

        }

        // Create Delete Question
        public void CreateQuestion()
        {

        }
        public void DeleteQuestion()
        {

        }

        // Create Delete Answer
        public void CreateAnswer()
        {

        }
        public void DeleteAnswer()
        {

        }

        public void Announce(string message)
        {
            Clients.All.Announce(message);
        }
    }
}