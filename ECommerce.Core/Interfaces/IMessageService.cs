using ECommerce.Core.ViewModels;

namespace ECommerce.Core.Interfaces
{
    public interface IMessageService
    {
        public MessageViewModel GetMessageByID(int MessageID);
        public List<MessageViewModel> GetMessagesBetweenUser(string FirstUser, string SecondUser);
        public int SendMessage(MessageViewModel MessageVM);
        public int EditMessage(int MessageID, string MessageBody);
    }
}
