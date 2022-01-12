using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Models;
using CBProject.Models.EntityModels;
using System;
using System.Linq;

namespace CBProject.Areas.Forum.HelperClasses
{
    public static class CreateForumsTestData
    {
        public static void CreateMessagesTestData(ApplicationDbContext context)
        {
            var user1 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios1@gmail.com"));
            var user2 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios2@gmail.com"));
            var user3 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios3@gmail.com"));
            var user4 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios4@gmail.com"));
            var user5 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios5@gmail.com"));
            ApplicationUser[] users = { user1, user2, user3, user4, user5 };

            Random random = new Random();

            for (int i = 1; i < 50; i++) {
                context.ForumMessages.Add(new ForumMessage()
                {
                    ID = i,
                    User = users[random.Next(0, 5)],
                    SendDate = DateTime.Now,
                    Message = $"Test Message {i}"
                });
            }
            context.SaveChanges();
        }
        public static void CreateQuestionsTestData(ApplicationDbContext context)
        {
            var user1 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios1@gmail.com"));
            var user2 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios2@gmail.com"));
            var user3 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios3@gmail.com"));
            var user4 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios4@gmail.com"));
            var user5 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios5@gmail.com"));
            ApplicationUser[] users = { user1, user2, user3, user4, user5 };

            Random random = new Random();

            for (int i = 1; i < 50; i++)
            {
                context.ForumQuestions.Add(new ForumQuestion()
                {
                    ID = i,
                    User = users[random.Next(0, 5)],
                    SendDate = DateTime.Now,
                    Question = $"Question: {i}"
                });
            }
            context.SaveChanges();
        }
        public static void CreateAnswersTestData(ApplicationDbContext context)
        {
            var user1 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios1@gmail.com"));
            var user2 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios2@gmail.com"));
            var user3 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios3@gmail.com"));
            var user4 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios4@gmail.com"));
            var user5 = context.Users.FirstOrDefault(u => u.Email.Equals("alexandrosplatanios5@gmail.com"));
            ApplicationUser[] users = { user1, user2, user3, user4, user5 };

            Random random = new Random();

            for (int i = 1; i < 50; i++)
            {
                var question = context.ForumQuestions.FirstOrDefault(q => q.ID == i);
                context.ForumAnswers.Add(new ForumAnswer()
                {
                    ID = i,
                    User = users[random.Next(0, 5)],
                    SendDate = DateTime.Now,
                    Question = question,
                    Answer = $"Answer {i} To Question: '{question.Question}'"
                });
            }
            context.SaveChanges();
        }

        public static void CreateAll(ApplicationDbContext context)
        {
            CreateMessagesTestData(context);
            CreateQuestionsTestData(context);
            CreateAnswersTestData(context);
        }
    }
}


