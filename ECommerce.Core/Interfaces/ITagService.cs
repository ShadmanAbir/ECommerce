using ECommerce.Core.ViewModels;
namespace ECommerce.Core.Interfaces
{
    public interface ITagService
    {
        public List<TagViewModel> GetAll();
        public TagViewModel GetTagByName(string TagName);
        public bool CreateTag(TagViewModel TagVM);
        public bool EditTag(TagViewModel TagVM);
    }
}
