using AutoMapper;
using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;

namespace ECommerce.Core.Services
{
    public class TagService : ITagService
    {
        private readonly IMapper _mapper;
        public TagService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool CreateTag(TagViewModel TagVM)
        {
            throw new NotImplementedException();
        }

        public bool EditTag(TagViewModel TagVM)
        {
            throw new NotImplementedException();
        }

        public List<TagViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TagViewModel GetTagByName(string TagName)
        {
            throw new NotImplementedException();
        }
    }
}
