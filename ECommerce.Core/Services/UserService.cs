using AutoMapper;
using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        public readonly UserManager<IdentityUser> _userManager;
        public UserService(IMapper mapper, UnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public int BlockUser(string BlockUser, string UserName)
        {
            var data = _unitOfWork.BlockListRepository.Get().FirstOrDefault(a => a.UserName == UserName && a.BlockedUser == BlockUser && a.IsDeleted == false);

            if (data != null)
            {
                throw new Exception("User Already Blocked");
            }
            else
            {
                var block = new UserBlockList
                {

                    UserName = BlockUser,
                    BlockedUser = UserName,
                    IsDeleted = false
                };
                _unitOfWork.BlockListRepository.Insert(block);
            }

            return _unitOfWork.Save();
        }

        public List<string> GetBlockListOfUser(string UserName)
        {
            return _unitOfWork.BlockListRepository.Get().Where(a => a.UserName == UserName && a.IsDeleted != true).Select(a => a.BlockedUser).ToList();
        }

        public int UnblockUser(string BlockUser, string UserName)
        {
            var data = _unitOfWork.BlockListRepository.Get().FirstOrDefault(a => a.UserName == UserName && a.BlockedUser == BlockUser && a.IsDeleted == false);
            if (data == null)
                throw new Exception("User Not Blocked");
            data.IsDeleted = true;
            _unitOfWork.BlockListRepository.Update(data);
            return _unitOfWork.Save();
        }

        public List<AspNetUsersViewModel> Users()
        {
            var data = _userManager.Users;
            return _mapper.ProjectTo<AspNetUsersViewModel>(data).ToList();
        }
    }
}
