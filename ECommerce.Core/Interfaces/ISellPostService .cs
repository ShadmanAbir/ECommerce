using ECommerce.Core.ViewModels;

namespace ECommerce.Core.Interfaces
{
    public interface ISellPostService
    {
        public SellPostViewModel GetSellPostByID(int SellPostID);
        public List<SellPostViewModel> GetAllSellPostsOfUser(string userName);
        public List<SellPostViewModel> GetSellPostsbyProduct(string ProductName);
        public List<SellPostViewModel> GetSellPostsbyTags(List<string> Tags);
        public int CreateSellPost(SellPostViewModel sellpostVM);
        public int UpdateSellPost(SellPostViewModel sellpostVM);
    }
}
