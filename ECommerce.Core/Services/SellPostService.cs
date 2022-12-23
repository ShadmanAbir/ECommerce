using AutoMapper;
using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Domain.UnitOfWork;

namespace ECommerce.Core.Services
{
    public class SellPostService : ISellPostService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        public SellPostService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int CreateSellPost(SellPostViewModel sellpostVM)
        {
            var SellPost = _mapper.Map<SellPost>(sellpostVM);
            _unitOfWork.SellPostRepository.Insert(SellPost);
            _unitOfWork.Save();
            foreach (var item in sellpostVM.Tags)
            {
                int tagID = 0;
                var tagexist = _unitOfWork.TagRepository.Get().SingleOrDefault(a => a.TagName == item);
                if (tagexist == null)
                {
                    var Tag = new Tag()
                    {
                        TagName = item
                    };
                    _unitOfWork.TagRepository.Insert(Tag);
                    _unitOfWork.Save();
                    tagID = Tag.TagID;
                }
                if (tagexist != null)
                    tagID = tagexist.TagID;
                var SalesTag = _unitOfWork.SellPostWiseTagRepository.Get().Any(a => a.TagID == tagID && a.SellPostID == SellPost.PostID);
                if (!SalesTag)
                {
                    var PostWisetag = new SellPostWiseTag()
                    {
                        SellPostID = SellPost.PostID,
                        TagID = tagID
                    };
                    _unitOfWork.SellPostWiseTagRepository.Insert(PostWisetag);
                    return _unitOfWork.Save();
                }

            }
            throw new Exception();
        }


        public SellPostViewModel GetSellPostByID(int SellPostID)
        {
            var SellPost = _unitOfWork.SellPostRepository.GetByID(SellPostID);
            return _mapper.Map<SellPostViewModel>(SellPost);
        }

        public int UpdateSellPost(SellPostViewModel sellpostVM)
        {
            var SellPost = _mapper.Map<SellPost>(sellpostVM);
            _unitOfWork.SellPostRepository.Update(SellPost);
            return _unitOfWork.Save();
        }

        public List<SellPostViewModel> GetAllSellPostsOfUser(string UserName)
        {
            var SellPostList = _unitOfWork.SellPostRepository.Get().Where(a => a.PostCreator == UserName);
            return _mapper.ProjectTo<SellPostViewModel>(SellPostList).ToList();
        }

        public List<SellPostViewModel> GetSellPostsbyProduct(string ProductName)
        {
            var SellPostList = from sp in _unitOfWork.SellPostRepository.Get()
                               join p in _unitOfWork.ProductRepository.Get() on sp.ProductID equals p.ProductID
                               where p.Name.Normalize() == ProductName.Normalize()
                               select sp;
            return _mapper.ProjectTo<SellPostViewModel>(SellPostList).ToList();
        }

        public List<SellPostViewModel> GetSellPostsbyTags(List<string> Tags)
        {
            var SellPostList = from sp in _unitOfWork.SellPostRepository.Get()
                               join p in _unitOfWork.SellPostWiseTagRepository.Get() on sp.PostID equals p.SellPostID
                               join t in _unitOfWork.TagRepository.Get() on p.TagID equals t.TagID
                               join st in Tags.AsQueryable() on t.TagName equals st
                               select sp;
            return _mapper.ProjectTo<SellPostViewModel>(SellPostList).ToList();
        }
    }
}
