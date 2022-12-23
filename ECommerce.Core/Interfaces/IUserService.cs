using ECommerce.Core.ViewModels;

namespace ECommerce.Core.Interfaces
{
    public interface IUserService
    {
        public List<string> GetBlockListOfUser(string UserName);
        public int BlockUser(string BlockUser, string UserName);
        public int UnblockUser(string BlockUser, string UserName);
        public List<AspNetUsersViewModel> Users();
    }
}
