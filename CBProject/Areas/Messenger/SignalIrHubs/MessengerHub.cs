using CBProject.Areas.Messenger.Repositories;
using CBProject.HelperClasses.Interfaces;
using Microsoft.AspNet.SignalR;

namespace CBProject.Areas.Messenger
{
    public class MessengerHub : Hub
    {

        private readonly MesGroupsRepository _mesGroupsRepository;
        private readonly MesMessagesRepository _mesMessagesRepository;

        public MessengerHub(IUnitOfWork unitOfWork)
        {
            this._mesGroupsRepository = unitOfWork.MessengerGroups;
            this._mesMessagesRepository = unitOfWork.MessengerMessages;
        }

        // Create Delete Group
        public void CreateGroup()
        {

        }
        public void DeleteGroup()
        {

        }

        // Create Delete Message
        public void CreateMessage()
        {

        }
        public void DeleteMessage()
        {

        }

    }
}