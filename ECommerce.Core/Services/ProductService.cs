using AutoMapper;
using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using ECommerce.Domain.Models;
using ECommerce.Domain.UnitOfWork;

namespace ECommerce.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        public ProductService(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public int CreateProduct(ProductViewModel productVM)
        {
            var product = _mapper.Map<Product>(productVM);
            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Save();
            return product.ProductID;
        }

        public List<ProductViewModel> GetAllProduct()
        {
            var ProductList = _unitOfWork.ProductRepository.Get();
            return _mapper.ProjectTo<ProductViewModel>(ProductList).ToList();
        }

        public ProductViewModel GetProductByID(int ProductID)
        {
            var Product = _unitOfWork.ProductRepository.GetByID(ProductID);
            return _mapper.Map<ProductViewModel>(Product);
        }

        public int UpdateProduct(ProductViewModel productVM)
        {
            var product = _mapper.Map<Product>(productVM);
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Save();
            return product.ProductID;
        }
    }
}
