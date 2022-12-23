using AutoMapper;
using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Domain.UnitOfWork;

namespace ECommerce.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        public MessageService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int EditMessage(int MessageID, string MessageBody)
        {
            var Message = _unitOfWork.MessageRepository.GetByID(MessageID);
            _unitOfWork.MessageRepository.Update(Message);
            return _unitOfWork.Save();
        }

        public MessageViewModel GetMessageByID(int MessageID)
        {
            var Message = _unitOfWork.MessageRepository.GetByID(MessageID);
            return _mapper.Map<MessageViewModel>(Message);
        }

        public List<MessageViewModel> GetMessagesBetweenUser(string FirstUser, string SecondUser)
        {
            var Message = _unitOfWork.MessageRepository.Get().Where(a => (a.SenderID == FirstUser || a.SenderID == SecondUser) && (a.ReceiverID == FirstUser || a.ReceiverID == SecondUser)).OrderByDescending(a => a.LastModifiedDate);
            return _mapper.ProjectTo<MessageViewModel>(Message).ToList();
        }

        public int SendMessage(MessageViewModel MessageVM)
        {
            var BlockStatus = _unitOfWork.BlockListRepository.Get().FirstOrDefault(a => (a.UserName == MessageVM.SenderID || a.BlockedUser == MessageVM.SenderID || a.UserName == MessageVM.ReceiverID || a.BlockedUser == MessageVM.ReceiverID) && a.IsDeleted != true);
            if (BlockStatus != null)
            {
                if (BlockStatus.UserName == MessageVM.SenderID)
                    throw new Exception("You Blocked The user");
                if (BlockStatus.BlockedUser == MessageVM.SenderID)
                    throw new Exception("You have been Blocked by The user");
            }
            MessageVM.LastModifiedDate = DateTime.Now;
            var Message = _mapper.Map<Message>(MessageVM);
            _unitOfWork.MessageRepository.Insert(Message);
            return _unitOfWork.Save();
        }
    }
}
